using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMedium : MonoBehaviour
{
    [SerializeField]
    //private GameObject[] colliderList;

    private List<GameObject> asteroids = new List<GameObject>();
    //int index;
    GameObject AsteroidsOBJ;
    private void Start()
    {


    }
    private void Update()
    {
        foreach (GameObject asteroidsnew in asteroids)
        {

            //Debug.Log(asteroidsnew);
            AsteroidsOBJ = asteroidsnew;
            float radius = this.GetComponentInChildren<SpriteRenderer>().bounds.extents.magnitude / 2;
            float radiusTwo = AsteroidsOBJ.GetComponent<SpriteRenderer>().bounds.extents.magnitude / 2;
            Debug.Log(radiusTwo);

            float sidea = Mathf.Abs(this.gameObject.transform.position.x - AsteroidsOBJ.gameObject.transform.position.x);
            float sideb = Mathf.Abs(this.gameObject.transform.position.y - AsteroidsOBJ.gameObject.transform.position.y);
            sidea = sidea * sidea;
            sideb = sideb * sideb;
            float distance = (float)Mathf.Sqrt(sidea + sideb);

            if (distance < radius + radiusTwo)
            {
                Debug.Log("Hit");

                if (AsteroidsOBJ.name == "AsteroidSmal" || AsteroidsOBJ.name == "AsteroidBig")
                {
                    asteroids.Remove(AsteroidsOBJ);
                    Destroy(AsteroidsOBJ.transform.parent.gameObject);


                }
                /*
                if (AsteroidsOBJ.name == "LaserShot")
                {
                    Destroy(this.gameObject);
                }
                */
                if (asteroids.Count == 0)
                {
                    return;
                }

                if (AsteroidsOBJ.name == "Ship")
                {
                    asteroids.Remove(AsteroidsOBJ);
                    Destroy(AsteroidsOBJ.transform.parent.gameObject);

                    Debug.Log("YOu died");
                }
            }
            /*
            if (distance < 0.6)
            {
                Destroy(AsteroidsOBJ);
            }
            */
            //   Debug.Log(AsteroidsOBJ);
        }
        /*
          float radius = GetComponent<SpriteRenderer>().bounds.extents.magnitude /2;
          float radiusTwo = gameObject.GetComponent<SpriteRenderer>().bounds.extents.magnitude /2;

          float sidea = Mathf.Abs(this.gameObject.transform.position.x - colliderList.gameObject.transform.position.x);
          float sideb = Mathf.Abs(this.gameObject.transform.position.y - colliderList.gameObject.transform.position.y);
          sidea = sidea * sidea;
          sideb = sideb * sideb;
          float distance = (float)Mathf.Sqrt(sidea + sideb);

          if (distance < radius + radiusTwo)
          {
            Debug.Log("Hit");

          }
          */


    }
    /*
    private void AsteroidCollision(GameObject asteroidsObj)
    {
       
        float radius = GetComponent<SpriteRenderer>().bounds.extents.magnitude / 2;
        float radiusTwo = AsteroidsOBJ.GetComponent<SpriteRenderer>().bounds.extents.magnitude / 2;

        float sidea = Mathf.Abs(this.gameObject.transform.position.x - AsteroidsOBJ.gameObject.transform.position.x);
        float sideb = Mathf.Abs(this.gameObject.transform.position.y - AsteroidsOBJ.gameObject.transform.position.y);
        sidea = sidea* sidea;
        sideb = sideb* sideb;
        float distance = (float)Mathf.Sqrt(sidea + sideb);

        if (distance<radius + radiusTwo)
        {
          Debug.Log("Hit");
         
        }
    }
 
    */
}
