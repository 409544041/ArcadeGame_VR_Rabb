using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour
{
    //Player and player laser
    [Header("Player")]
    [SerializeField]
    private GameObject laser;
    [SerializeField]
    private GameObject youWin;
    [SerializeField]
    private GameObject instantiatePlayer;
    [SerializeField]
    private Transform spawnPoint;
    private List<GameObject> laserShots = new List<GameObject>();
    private float cooldown = 1f;
    private float time = 0f;
    private bool playerHit = false;
    public bool playerSpawned = false;
    public GameObject spawnedPlayer;

    [SerializeField]
    [Header("AsteroidInstantiate")]
    private GameObject asteroidM;
    [SerializeField]
    private GameObject asteroidS;

    private List<GameObject> asteroids = new List<GameObject>();
    GameObject asteroid;


    //Spawn Asteroids when Big and Medium has been hit so it will be divided into two
    [SerializeField]
    private GameObject[] asteroidsSpawn;
    [SerializeField]
    private GameObject[] spawnPositions;

    public float spawnRate;
    [SerializeField]
    private int spawnNR;

    [SerializeField]
    private GameObject collidingEffect;
    //Access to the gamemanagerscript to get Life and Score variables
    GameManager gameManagerScript;
    [SerializeField]
    private GameObject gameMenu;

    [SerializeField]
    private AudioClip[] gameSounds;
    private AudioSource playSounds;
    private void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnNR = Random.Range(3, spawnNR);
        StartCoroutine(SpawnAsteroids());
        playSounds = this.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!gameMenu.activeSelf && playerSpawned == false)
        {
            spawnedPlayer = Instantiate(instantiatePlayer, spawnPoint.transform.position, spawnPoint.transform.rotation);
            spawnedPlayer.SetActive(true);
            playerSpawned = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        foreach (GameObject asteroidsnew in asteroids.ToArray())
        {

            asteroid = asteroidsnew; // eventuellt behövs inte denna

            foreach (var laserShot in laserShots)
            {
                if (laserShot != null)
                {
                    
                    //check if laser collides with asteroids
                    if (IsCollision(laserShot, asteroid))
                    {
                        PlaySound(1);
                        Destroy(asteroid);
                        asteroids.Remove(asteroid);
                        Destroy(laserShot);
                        var asteroidAs = asteroid.GetComponent<Asteroids>();

                        if (asteroidAs.size == Asteroids.AsteroidSize.Big)
                        {
                            StartCoroutine(SetCollisionEffectLaser(laserShot));
                            CreateAsteroids(asteroidM, laserShot.transform);
                            gameManagerScript.AddScore(1);
                        }

                        if (asteroidAs.size == Asteroids.AsteroidSize.Medium)
                        {
                            StartCoroutine(SetCollisionEffectLaser(laserShot));
                            CreateAsteroids(asteroidS, laserShot.transform);
                            gameManagerScript.AddScore(3);
                        }
                        if (asteroidAs.size == Asteroids.AsteroidSize.Small)
                        {
                            StartCoroutine(SetCollisionEffectLaser(laserShot));
                            gameManagerScript.AddScore(5);
                        }

                        if (asteroids.Count == 0)
                        {

                            youWin.SetActive(true);

                        }
                    }
                }


            }
            if (spawnedPlayer != null)
            {
                //Check If Player taking damage or if player is dead              
                if (playerHit == false && IsCollision(spawnedPlayer, asteroid))
                {
                    PlaySound(2);
                    playerHit = true;
                    gameManagerScript.SubtractLives();

                    Destroy(asteroid);
                    asteroids.Remove(asteroid);
                    var asteroidAs = asteroid.GetComponent<Asteroids>();

                    if (asteroidAs.size == Asteroids.AsteroidSize.Big)
                    {
                        StartCoroutine(SetCollisionEffect());
                        CreateAsteroids(asteroidM, spawnedPlayer.transform);
                    }

                    if (asteroidAs.size == Asteroids.AsteroidSize.Medium)
                    {
                        StartCoroutine(SetCollisionEffect());
                        CreateAsteroids(asteroidS, spawnedPlayer.transform);

                    }

                    if (asteroidAs.size == Asteroids.AsteroidSize.Small)
                    {
                        StartCoroutine(SetCollisionEffect());
                    }

                    StartCoroutine(ResetPlayerHitBool());
                    if (gameManagerScript.lives == 0)
                    {

                        Destroy(spawnedPlayer);
                        playerSpawned = false;
                        gameMenu.SetActive(true);

                    }
                }
            }
        }

    }

    private bool IsCollision(GameObject object1, GameObject object2)
    {
        var object1Radius = object1.GetComponentInChildren<SpriteRenderer>().bounds.extents.magnitude / 2;
        var object2Radius = object2.GetComponentInChildren<SpriteRenderer>().bounds.extents.magnitude / 2;
        var distanceXPlayer = Mathf.Abs(object1.gameObject.transform.position.x - object2.gameObject.transform.position.x);
        var distanceYPlayer = Mathf.Abs(object1.gameObject.transform.position.y - object2.gameObject.transform.position.y);
        var distanceXSquaredPlayer = distanceXPlayer * distanceXPlayer;
        var distanceYSquaredPlayer = distanceYPlayer * distanceYPlayer;
        var distancePlayer = (float)Mathf.Sqrt(distanceXSquaredPlayer + distanceYSquaredPlayer);
        return distancePlayer < object1Radius + object2Radius;
    }

    private void CreateAsteroids(GameObject asteroid, Transform transform)
    {
        GameObject asteroid1 = Instantiate(asteroid, transform.position, transform.rotation);
        GameObject asteroid2 = Instantiate(asteroid, transform.position, transform.rotation);
        asteroids.Add(asteroid1);
        asteroids.Add(asteroid2);
    }

    IEnumerator ResetPlayerHitBool()
    {
        yield return new WaitForSeconds(0.3f);
        playerHit = false;
    }
    //ShootLaser
    void Shoot()
    {

        if (time > 0f)
        {
            time -= Time.deltaTime;

        }

        var laserShot = Instantiate(laser, spawnedPlayer.GetComponentInChildren<SpriteRenderer>().transform.TransformPoint(Vector3.up * 1), spawnedPlayer.GetComponentInChildren<SpriteRenderer>().transform.rotation);
        laserShot.SetActive(true);
        laserShots.Add(laserShot);
        PlaySound(0);
        time = cooldown;
    }

    private void PlaySound(int soundToPlay)
    {
        playSounds.clip = gameSounds[soundToPlay];
        playSounds.Play();
    }

    //SpawnAsteroids with a sligth pause
    private IEnumerator SpawnAsteroids()
    {
        for (int i = 0; i < spawnNR; i++)
        {
            Vector2 position = spawnPositions[Random.Range(0, spawnPositions.Length)].transform.position;
            GameObject asteroidClone = Instantiate(asteroidsSpawn[Random.Range(0, asteroidsSpawn.Length)], new Vector2(position.x, position.y), transform.rotation);
            asteroidClone.SetActive(true);
            asteroids.Add(asteroidClone);
            yield return new WaitForSeconds(3);
        }

    }
    IEnumerator SetCollisionEffect()
    {
        collidingEffect.transform.position = spawnedPlayer.transform.position;
        collidingEffect.transform.rotation = spawnedPlayer.transform.rotation;
        collidingEffect.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        collidingEffect.SetActive(false);
    }

    IEnumerator SetCollisionEffectLaser(GameObject laser)
    {
        //ta ett argument gameobject
        collidingEffect.transform.position = laser.transform.position;
        collidingEffect.transform.rotation = laser.transform.rotation;
        collidingEffect.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        collidingEffect.SetActive(false);
    }
}
