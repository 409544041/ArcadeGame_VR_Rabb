using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    //Movement
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

    private bool isThrusting = false;

    //Acceleration and Decelartion
    private float initialVelocity = 0.5f;
    private float finalVelocity = 2f;
    [SerializeField]
    private float currentVelocity = 0.5f;
    [SerializeField]
    private float accelerationRate = 0.1f;
    [SerializeField]
    private float decelerationRate = 0.1f;

    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float rotateMax;

    //SoundFX
    [SerializeField]
    private AudioClip[] playerSoundsFX;
    private AudioSource myAudiosource;
    private bool isPlaying = false;

    private void Start()
    {
        myAudiosource = this.gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {

        if (currentVelocity<2.1 && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {         
                finalVelocity = 2;
                Accelerate();    
                rocket.SetActive(true);
                PlaySoundFX();
                isThrusting = false;
        }
        else
        {
            Deaccelerate();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            rocket.SetActive(false);
            isPlaying = false;
        }

       Vector3 rotationZ = new Vector3(0f, 0f, Input.GetAxis("Horizontal") * -1f);
        transform.Rotate(rotationZ * Time.deltaTime * rotationSpeed);
        
        //Thrust
        if (Input.GetKeyDown(KeyCode.LeftShift) && isThrusting == false)
        {
            
            finalVelocity = 4;
            // accelerationRate = 1f;
            isThrusting = true;
            Thrust();
            
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            thrust.SetActive(false);
        }

    }

    void PlaySoundFX()
    {
        myAudiosource.clip = playerSoundsFX[0];
        if (!myAudiosource.isPlaying)
        {
            myAudiosource.Play();
        }
    }

    void Accelerate()
    {

       currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);
       currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, finalVelocity);
        transform.Translate(transform.up * currentVelocity * Time.deltaTime, Space.World);

    }

    void Thrust()
    {
        do
        {
            PlaySoundFX();
            rocket.SetActive(false);
            thrust.SetActive(true);
            currentVelocity = currentVelocity + (10.0f * Time.deltaTime);
        }
        while (currentVelocity < 4);
    }

    void Deaccelerate()
    {
        if (currentVelocity > 2)
        {
            currentVelocity = currentVelocity - (0.2f* Time.deltaTime);
          
        }
        currentVelocity = currentVelocity - (decelerationRate * Time.deltaTime);
        currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, finalVelocity);
        transform.position += transform.up * currentVelocity * Time.deltaTime;
    }
}
