using UnityEngine;
public class PlayerController : MonoBehaviour
{
    //Movement
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private GameObject rocket;
    [SerializeField]
    private GameObject thrust;
    private bool isThrusting = false;
    [SerializeField]
    private GameObject spritePlayer;
    //Acceleration and Decelartion
    private float initialSpeed = 0.5f;
    private float finalSpeed = 2f;
    [SerializeField]
    private float currentSpeed = 0.5f;
    [SerializeField]
    private float accelerationRate = 0.1f;
    [SerializeField]
    private float decelerationRate = 0.1f;

    //SoundFX
    [SerializeField]
    private AudioClip[] playerSoundsFX;
    private AudioSource myAudiosource;
   

    private void Start()
    {
        myAudiosource = this.gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        //Move Forward
        if (currentSpeed < 2.1 && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            finalSpeed = 2;
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
          
        }

        //Rotation
        Vector3 rotationZ = new Vector3(0f, 0f, Input.GetAxis("Horizontal") * -1f);
        transform.Rotate(rotationZ * Time.deltaTime * rotationSpeed);
       // spritePlayer.transform.Rotate(rotationZ * Time.deltaTime * rotationSpeed, Space.Self);

        //Thrust
        if (Input.GetKeyDown(KeyCode.LeftShift) && isThrusting == false)
        {
            finalSpeed = 4;
            isThrusting = true;
            Thrust();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            thrust.SetActive(false);
        }

    }



    void Accelerate()
    {

        currentSpeed = currentSpeed + (accelerationRate * Time.deltaTime);
        currentSpeed = Mathf.Clamp(currentSpeed, initialSpeed, finalSpeed);
        transform.Translate(transform.up * currentSpeed * Time.deltaTime, Space.World);

    }

    void Thrust()
    {
        do
        {
            PlaySoundFX();
            rocket.SetActive(false);
            thrust.SetActive(true);
            currentSpeed = currentSpeed + (10.0f * Time.deltaTime);
        }
        while (currentSpeed < 4);
    }

    void Deaccelerate()
    {
        if (currentSpeed > 2)
        {
            currentSpeed = currentSpeed - (0.2f * Time.deltaTime);

        }
        if (currentSpeed < 2)
        {
            isThrusting = false;
        }
        currentSpeed = currentSpeed - (decelerationRate * Time.deltaTime);
        currentSpeed = Mathf.Clamp(currentSpeed, initialSpeed, finalSpeed);
        transform.position += transform.up * currentSpeed * Time.deltaTime;
    }

    void PlaySoundFX()
    {
        myAudiosource.clip = playerSoundsFX[0];
        if (!myAudiosource.isPlaying)
        {
            myAudiosource.Play();
        }
    }
}
