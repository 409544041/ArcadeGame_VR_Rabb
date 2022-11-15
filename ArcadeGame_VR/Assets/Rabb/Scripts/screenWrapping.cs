using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenWrapping : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 7.3f)
        {
            ChangePositionX(-1, +0.1f);
            
        }

        if (transform.position.x < -7.3f)
        {
            ChangePositionX(-1, -0.1f);          
        }

        if (transform.position.y > 5.52f)
        {
            ChangePositionY(-1, +0.1f);
           
        }
        if (transform.position.y < -5.52f)
        {
            ChangePositionY(-1, -0.1f);
          
        }
    }

    void ChangePositionX(int posXwrap, float jittersafeX)
    {
        float newPosX = transform.position.x * posXwrap + jittersafeX;
        transform.position = new Vector3(newPosX, transform.position.y);
    }

    void ChangePositionY(int posYwrap, float jittersafeY)
    {
        float newPosY = transform.position.y * posYwrap + jittersafeY;
        transform.position = new Vector3(transform.position.x, newPosY);
    }
}