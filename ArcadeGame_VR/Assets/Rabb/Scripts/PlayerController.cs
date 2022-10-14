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
    //private GameObject clone;
    [SerializeField]
    private float cooldown = 1f;
    private float time = 0f;
    //bool cloned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (time > 0f)
        {
            time -= Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
             Instantiate(laser, transform.TransformPoint(Vector3.up *1), transform.rotation);
           
            time = cooldown;
        }
        /*
        if (cloned == true)
        {
            clone.transform.position += clone.transform.up * movementSpeed * Time.deltaTime;
        }
        */
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed *Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * movementSpeed * Time.deltaTime;
        }
        /*
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y < (Screen.height - 10f))
            Destroy(clone);
        */
    }
  
}
