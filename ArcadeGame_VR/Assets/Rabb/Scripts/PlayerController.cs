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
    private float cooldown = 1f;
    private float time = 0f;
    [SerializeField]
    private GameObject rocket;
    [SerializeField]
    private GameObject thrust;
    // Update is called once per frame
    void Update()
    {
        //Forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * movementSpeed * Time.deltaTime;
            rocket.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            rocket.SetActive(false);
        }
        //rotate left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed *Time.deltaTime);
        }
        //rotate right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }       
        //Thrust
        if(Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = 6;
            rocket.SetActive(false);
            thrust.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = 3;
            thrust.SetActive(false);
        }

        //Laser
        if (time > 0f)
        {
            time -= Time.deltaTime;

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laser, transform.TransformPoint(Vector3.up * 1), transform.rotation);
            time = cooldown;
        }
    }
}
