using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    [SerializeField]
    [Header("Weapon")]
    private GameObject Laser;

    [SerializeField]
    [Header("AsteroidInstantiate")]
    private GameObject asteroidM;
    [SerializeField]
    private GameObject asteroidS;

    [SerializeField]
    //private GameObject[] colliderList;

    private List<GameObject> asteroids = new List<GameObject>();
    //int index;
    GameObject AsteroidsOBJ;

    GameManager gameManagerScript;


    private float cooldown = 1f;
    private float time = 0f;
    private float radius;
    private float radiusTwo;
    private float radiusPlayer;
    float sidea;
    float sideb;
    private GameObject LaserClone;
    //Spawn Asteroids
    [SerializeField]
    private GameObject[] asteroidsSpawn;
    [SerializeField]
    private GameObject[] spawnPositions;

    public float spawnRate;
    [SerializeField]
    private int SpawnNR;
    private bool playerHit = false;
    private void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine(SpawnAsteroids());
        SpawnNR = Random.Range(3, SpawnNR);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        foreach (GameObject asteroidsnew in asteroids.ToArray())
        {

            AsteroidsOBJ = asteroidsnew;
            if (LaserClone != null)
            {
                //check if laser collides with asteroids
                radius = LaserClone.GetComponentInChildren<SpriteRenderer>().bounds.extents.magnitude / 2;
                radiusTwo = AsteroidsOBJ.GetComponent<SpriteRenderer>().bounds.extents.magnitude / 2;
                sidea = Mathf.Abs(LaserClone.gameObject.transform.position.x - AsteroidsOBJ.gameObject.transform.position.x);
                sideb = Mathf.Abs(LaserClone.gameObject.transform.position.y - AsteroidsOBJ.gameObject.transform.position.y);
                sidea = sidea * sidea;
                sideb = sideb * sideb;
                float distance = (float)Mathf.Sqrt(sidea + sideb);

               
                if (distance < radius + radiusTwo)
                {

                    
                    //Debug.Log("Hit");

                    asteroids.Remove(AsteroidsOBJ);
                    Destroy(AsteroidsOBJ);

                    Destroy(LaserClone);
                    Debug.Log(AsteroidsOBJ.name);
                    if (AsteroidsOBJ.name == "AsteroidBig(Clone)")
                    {
                        
                        GameObject asteroid1 = Instantiate(asteroidM, LaserClone.transform.position, LaserClone.transform.rotation);
                        GameObject asteroid2 = Instantiate(asteroidM, LaserClone.transform.position, LaserClone.transform.rotation);
                        asteroids.Add(asteroid1);
                        asteroids.Add(asteroid2);
                        gameManagerScript.AddScore(3);
                    }

                    if (AsteroidsOBJ.name == "AsteroidMedium(Clone)" || AsteroidsOBJ.name == "AsteroidMInstantiate(Clone)")
                    {
                       
                        GameObject asteroidS1 = Instantiate(asteroidS, LaserClone.transform.position, LaserClone.transform.rotation);
                        GameObject asteroidS2 = Instantiate(asteroidS, LaserClone.transform.position, LaserClone.transform.rotation);
                        asteroids.Add(asteroidS1);
                        asteroids.Add(asteroidS2);
                        gameManagerScript.AddScore(2);
                    }
                    if (AsteroidsOBJ.name == "AsteroidSmal(Clone)" || AsteroidsOBJ.name ==  "AsteroidSmalInstantiate(Clone)")
                    {
                        gameManagerScript.AddScore(1);
                    }

                    if (asteroids.Count == 0)
                    {
                        return;
                    }
                   
                    // check if player is colliding
                    

                    /*
                    if (AsteroidsOBJ.name == "Ship")
                    {
                        asteroids.Remove(AsteroidsOBJ);
                        Destroy(AsteroidsOBJ.transform.parent.gameObject);

                        Debug.Log("YOu died");
                    }
                    */

                }
            }
            //CHeck If Player take damage and dead
            radiusPlayer = player.GetComponent<SpriteRenderer>().bounds.extents.magnitude / 2;
            float sideaPlayer = Mathf.Abs(player.gameObject.transform.position.x - AsteroidsOBJ.gameObject.transform.position.x);
            float sidebPlayer = Mathf.Abs(player.gameObject.transform.position.y - AsteroidsOBJ.gameObject.transform.position.y);
            sideaPlayer = sideaPlayer * sideaPlayer;
            sidebPlayer = sidebPlayer * sidebPlayer;
            float distancePlayer = (float)Mathf.Sqrt(sideaPlayer + sidebPlayer);
            if (distancePlayer < radiusPlayer + radiusTwo && playerHit == false)
            {
                playerHit = true;
                Debug.Log("You Ddied");
                gameManagerScript.SubtractLives();
                StartCoroutine(ResetPlayerHitBool());
                if (gameManagerScript.lives == 0)
                {

                    player.transform.parent.gameObject.SetActive(false);
                 
                }
            }
           

        }

    }
    IEnumerator ResetPlayerHitBool()
    {
        yield return new WaitForSeconds(0.5f);
        playerHit = false;
    }

    void Shoot()
    {

        if (time > 0f)
        {
            time -= Time.deltaTime;

        }

        LaserClone = Instantiate(Laser, player.transform.TransformPoint(Vector3.up * 1), player.transform.rotation);
        LaserClone.SetActive(true);
        time = cooldown;
    }

    private IEnumerator SpawnAsteroids()
    {
        for (int i = 0; i < SpawnNR; i++)
        {

            Vector2 position = spawnPositions[Random.Range(0, spawnPositions.Length)].transform.position;
            GameObject asteroidClone = Instantiate(asteroids[Random.Range(0, asteroidsSpawn.Length)], new Vector2(position.x, position.y), transform.rotation);
            asteroidClone.SetActive(true);
            asteroids.Add(asteroidClone);
            yield return new WaitForSeconds(3);
        }

    }
}
