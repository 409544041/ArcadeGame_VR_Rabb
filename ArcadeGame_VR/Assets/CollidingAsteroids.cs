using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingAsteroids : MonoBehaviour
{
    [SerializeField]
    //private GameObject[] colliderList;

    private List<GameObject> asteroidsOriginal = new List<GameObject>();
    [SerializeField]
    private List<GameObject> asteroidsCrash = new List<GameObject>();
    // private List<GameObject> asteroidsOriginal = new List<GameObject>();
    //int index;
    GameObject AsteroidsOBJ;
    GameObject AsteroidsOBJCrash;
    //GameObject AsteroidsOBJCrash;
    private void Start()
    {


    }
    private void Update()
    {
        foreach (GameObject asteroidsCrash in asteroidsOriginal)
        {

            AsteroidsOBJCrash = asteroidsCrash;
        }
        foreach (GameObject asteroidsnew in asteroidsOriginal)
        {
            //Debug.Log(asteroidsnew);
            AsteroidsOBJ = asteroidsnew;
            
            float radius = AsteroidsOBJCrash.GetComponent<SpriteRenderer>().bounds.extents.magnitude / 2;
            float radiusTwo = AsteroidsOBJ.GetComponent<SpriteRenderer>().bounds.extents.magnitude / 2;
           // Debug.Log(radiusTwo);

            float sidea = Mathf.Abs(AsteroidsOBJCrash.gameObject.transform.position.x - AsteroidsOBJ.gameObject.transform.position.x);
            float sideb = Mathf.Abs(AsteroidsOBJCrash.gameObject.transform.position.y - AsteroidsOBJ.gameObject.transform.position.y);
            sidea = sidea * sidea;
            sideb = sideb * sideb;
            float distance = (float)Mathf.Sqrt(sidea + sideb);

            if (distance < radius + radiusTwo)
            {
                Debug.Log("Hit");

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
