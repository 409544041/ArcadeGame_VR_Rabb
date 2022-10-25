using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpeed : MonoBehaviour
{
    [SerializeField]
    private float laserSpeed;


    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * laserSpeed * Time.deltaTime;

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
