using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    [SerializeField]
    private float asteroidThrust;
    [SerializeField]
    private float asteroidThrustSpin;
    [SerializeField]
    private float asteroidSpin;
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
        transform.position += transform.up * asteroidThrust * Time.deltaTime;
        transform.position += transform.right * asteroidThrust * Time.deltaTime;
    }
}
