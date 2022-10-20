using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShotCollider : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroidB;
    [SerializeField]
    private GameObject asteroidM;
    [SerializeField]
    private GameObject asteroidS;
    //private List<GameObject> asteroids = new List<GameObject>();
    //int index;
    GameObject AsteroidsOBJ;
    private bool hit = false;
    private void Start()
    {


    }
    private void Update()
    {
        

            //Debug.Log(asteroidsnew);
           
            float radius = this.GetComponentInChildren<SpriteRenderer>().bounds.extents.magnitude / 2;
            float radiusTwo = asteroidB.GetComponentInChildren<SpriteRenderer>().bounds.extents.magnitude / 2;
            //Debug.Log(radius);

            float sidea = Mathf.Abs(this.gameObject.transform.position.x - asteroidB.gameObject.transform.position.x);
            float sideb = Mathf.Abs(this.gameObject.transform.position.y - asteroidB.gameObject.transform.position.y);
            sidea = sidea * sidea;
            sideb = sideb * sideb;
            float distance = (float)Mathf.Sqrt(sidea + sideb);

            if (distance < radius + radiusTwo && hit == false)
            {
                hit = true;
                Debug.Log("Hit");
            
                Destroy(asteroidB);
            

                if (asteroidB.name == "AsteroidBig")
                {
              
                GameObject asteroid1 = Instantiate(asteroidM, transform.position, transform.rotation);
                GameObject asteroid2 = Instantiate(asteroidM, transform.position, transform.rotation);
                }

                if (asteroidB.name == "AsteroidMedium")
                {

                GameObject asteroid1 = Instantiate(asteroidS, transform.position, transform.rotation);
                GameObject asteroid2 = Instantiate(asteroidS, transform.position, transform.rotation);
                }

        }
    }
    
}
