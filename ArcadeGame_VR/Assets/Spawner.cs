using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] asteroids;
    [SerializeField]
    private GameObject[] spawnPositions;
 
    public float spawnRate;
    [SerializeField]
    private int SpawnNR;

    private float NextSpawn;
    // Start is called before the first frame update
    void Start()
    {
       //Spawn();
        StartCoroutine(SpawnAsteroids());
        SpawnNR = Random.Range(3, SpawnNR);
    }

    // Update is called once per frame
    void Update()
    {
       
       
        
        
           // Spawn();
       
    }
    private IEnumerator SpawnAsteroids()
    {
        for (int i = 0; i < SpawnNR; i++)
        {
            
            Vector2 position = spawnPositions[Random.Range(0, spawnPositions.Length)].transform.position;
            GameObject asteroidClone = Instantiate(asteroids[Random.Range(0, asteroids.Length)], new Vector2(position.x, position.y), transform.rotation);
            asteroidClone.SetActive(true);
            yield return new WaitForSeconds(3);
        }

    }
    private void Spawn()
    {
        // 
        for (int i = 0; i < SpawnNR; i++)
        {
            Vector2 position = spawnPositions[Random.Range(0, spawnPositions.Length)].transform.position;
            GameObject asteroidClone = Instantiate(asteroids[Random.Range(0, asteroids.Length)], new Vector2(position.x, position.y), transform.rotation);
            asteroidClone.SetActive(true);
            
        }
        
    }
}
