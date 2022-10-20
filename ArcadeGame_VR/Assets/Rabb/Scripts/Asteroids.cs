using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
   // [SerializeField]
  //  private float maxThrust = 5f;
    [SerializeField]
    private float asteroidThrust;
    [SerializeField]
    private float asteroidThrustSpin;
    [SerializeField]
    private float asteroidSpin;
   // [SerializeField]
   // private float maxSpin = 10f;
   // [SerializeField]
   // GameObject sprite;
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        asteroidThrust = Random.Range(-5, 5f);
        asteroidThrustSpin = Random.Range(1, 3f);
        asteroidSpin = Random.Range(-180, 180);
    }

    // Update is called once per frame
    void Update()
    {



                transform.Rotate(0, 0, asteroidSpin *asteroidThrustSpin * Time.deltaTime, Space.Self); //rotate
                transform.Translate(asteroidThrust * Time.deltaTime, 0, 0, Space.World);  //move 
                transform.Translate(0, asteroidThrust * Time.deltaTime, 0, Space.World);

           
    }
        
}
