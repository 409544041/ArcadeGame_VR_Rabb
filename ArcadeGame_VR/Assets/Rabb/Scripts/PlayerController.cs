using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private GameObject laser;
    [SerializeField]
    private GameObject rocket;
    [SerializeField]
    private GameObject thrust;
    [SerializeField]
    private SpriteRenderer spritePlayer;

    //Acceleration and Decelartion
    private float initialVelocity = 0.0f;
    private float finalVelocity = 2f;
    [SerializeField]
    private float currentVelocity = 0.0f;
    [SerializeField]
    private float accelerationRate = 0.1f;
    [SerializeField]
    private float decelerationRate = 0.1f;
    Vector3 rot = new Vector3(0,0,1);
    Vector3 rotR = new Vector3(0, 0, -1);

    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float rotateMax;

    void Update()
    {

        transform.position += transform.up * 0.5f * Time.deltaTime;
        //Forward
       // transform.Translate(0, 0.5f * Time.deltaTime, 0, Space.World);
       

        if (Input.GetKey(KeyCode.W))
        {
            currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);

            transform.position += transform.up * currentVelocity * Time.deltaTime;
          //  transform.Translate(0, currentVelocity * Time.deltaTime, 0, Space.World);

            rocket.SetActive(true);

        }
        else
        {
            currentVelocity = currentVelocity - (decelerationRate * Time.deltaTime);
            // transform.Translate(0, currentVelocity * Time.deltaTime, 0, Space.World);
            transform.position += transform.up * currentVelocity * Time.deltaTime;

        }
        currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, finalVelocity);
        if (Input.GetKeyUp(KeyCode.W))
        {
            rocket.SetActive(false);

        }
        //rotate left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime, Space.Self);
            //rocket.transform.rotation = spritePlayer.transform.rotation;
            //transform.Rotate(0, 0, rotationSpeed * Time.deltaTime, Space.Self);
            spritePlayer.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime, Space.Self);
            //  transform.Rotate(rot);
        }
        //rotate right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime, Space.Self);
            // transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime, Space.Self);
            //spritePlayer.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime, Space.Self);
            rocket.transform.rotation = spritePlayer.transform.rotation;
            //transform.Rotate(rotR);
        }
        //Thrust
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentVelocity = 6;
            rocket.SetActive(false);
            thrust.SetActive(true);
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
           currentVelocity = 3;
            thrust.SetActive(false);
        }
        
    }

    private void ControllerTest()
    {
       
    }

    void fredriskController()
    {
        float thrustMovement = Input.GetAxis("Vertical");
        float rotateMovement = Input.GetAxis("Horizontal");

        transform.Rotate(0, 0, -rotateMovement * rotateMax * Time.deltaTime);

        transform.Translate(Vector3.up * thrustMovement * maxSpeed * Time.deltaTime);

        transform.Translate(Vector3.up * 0.5f * maxSpeed * Time.deltaTime);
    }
}
