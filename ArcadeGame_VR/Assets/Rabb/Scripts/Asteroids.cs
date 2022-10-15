using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    [SerializeField]
    private float maxThrust = 5f;
    [SerializeField]
    private float asteroidThrust;
    [SerializeField]
    private float asteroidThrustSpin;
    [SerializeField]
    private float asteroidSpin;
    [SerializeField]
    private float maxSpin = 10f;
    [SerializeField]
    private float asteroidStage;
    [SerializeField]
    GameObject sprite;

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


        switch (asteroidStage)
        {
            case 3:


                  transform.position += transform.up * asteroidThrust * Time.deltaTime;
                 transform.position += transform.right * asteroidThrust * Time.deltaTime;
                // transform.Rotate(Vector3.back *Time.deltaTime);
                // sprite.transform.Rotate(Vector3.back * 100 * Time.deltaTime, Space.Self);
                sprite.transform.Rotate(0, 0, asteroidSpin * asteroidThrustSpin * Time.deltaTime);
                // Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f));
                break;
        }

       
    }
    /*
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    */
}
