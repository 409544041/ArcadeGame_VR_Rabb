using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenWrapping : MonoBehaviour
{
    private float posZ = -0.05f;
    // Use this for initialization


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 7.3f)
        {
            float newPosX = transform.position.x * -1 + 0.1f;
            transform.position = new Vector3(newPosX, transform.position.y, posZ);
        }

        if (transform.position.x < -7.3f)
        {
            float newPosX = transform.position.x * -1 - 0.1f;
            transform.position = new Vector3(newPosX, transform.position.y, posZ);
        }

        if (transform.position.y > 5.52f)
        {
            float newPosY = transform.position.y * -1 + 0.1f;
            transform.position = new Vector3(transform.position.x, newPosY, posZ);
        }
        if (transform.position.y < -5.52f)
        {
            float newPosY = transform.position.y * -1 - 0.1f;
            transform.position = new Vector3(transform.position.x, newPosY, posZ);
        }
    }
}

