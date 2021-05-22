using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{[SerializeField] float mainThrust = 100f;
 public  float sideThrust = 200f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip Explosion;
    [SerializeField] AudioClip Win;
    [SerializeField] ParticleSystem Engine;
    [SerializeField] ParticleSystem ExplosionParticle;
    [SerializeField] ParticleSystem WinParticle;
    [SerializeField] float reduce;
    Rigidbody rocketBody;
    AudioSource rocketAudio;
   public Joystick joystick;
    bool IsPressed;
    [SerializeField] Transform WaypointOut;
    [SerializeField] Transform PortalWaypoint;
    bool isFloating;
    enum State { isAlive , trasending , dying};
    State state = State.isAlive;
    Fuel fuelSystem;
    Immunity RocketImmunity;
    public int NextSceneLoad;
   Animator ImmunityAnimator;
    // Start is called before the first frame update
    void Start()
    {
        NextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        rocketBody = GetComponent<Rigidbody>();
        rocketAudio = GetComponent<AudioSource>();
        fuelSystem = GetComponent<Fuel>();
        ImmunityAnimator = GetComponent<Animator>();
RocketImmunity =FindObjectOfType<Immunity>();
    }

    // Update is called once per frame
    void Update()
    {if(Time.timeScale == 0f) { return; }
        if (state == State.isAlive)
        {
           
            CheckPortal();
           
            ImmunityAnimator.SetBool("IMMUNITY",RocketImmunity.VideoAd);
            movement();
            if (fuelSystem.startFuel != 0)
            {
                JoystickMovement();
                Thurst();
            }
        }
    }

    

    private void FixedUpdate()
    {
        if (fuelSystem.startFuel == 0)
        {
            Engine.Stop();
            rocketAudio.Stop();
           
        }
    }
    public void PointerDown()
    {
        Debug.Log("Pressed");
        isFloating = true;
    }
    public void Pointerup()
    {
        Debug.Log("Pressed");
        isFloating = false;
    }
    private void CheckPortal()
    {if (WaypointOut == null||PortalWaypoint == null) { return; }
        float distance = Vector3.Distance(PortalWaypoint.position, transform.position);
        Debug.Log(distance);
        if(distance <=3 )
        {
            transform.position = WaypointOut.position;
        }
    }

    private void JoystickMovement()
    {
        float horizontalInput = joystick.Horizontal * sideThrust * Time.deltaTime;
        fuelSystem.FuelConsumptionRate = 0.2f;
        fuelSystem.reduceFuel();
        transform.Rotate(-Vector3.forward*horizontalInput);
    }

    private void movement()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward* Time.deltaTime * sideThrust);
            fuelSystem.FuelConsumptionRate = 0.2f;
            fuelSystem.reduceFuel();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward*Time.deltaTime * sideThrust);
            fuelSystem.FuelConsumptionRate = 0.2f;
            fuelSystem.reduceFuel();
        }
    }

    private void Thurst()
    {
        if (Input.GetKey(KeyCode.Space)|| isFloating ==true)
        {
            rocketBody.freezeRotation = true;
            rocketBody.AddRelativeForce(Vector3.up* Time.deltaTime * mainThrust);
            fuelSystem.FuelConsumptionRate = mainThrust * reduce;
            fuelSystem.reduceFuel();
            if (!rocketAudio.isPlaying)
            {
                rocketAudio.PlayOneShot(mainEngine);
            }
            Engine.Play();
        }
        else
        {
            rocketAudio.Stop();
            Engine.Stop();
            rocketBody.freezeRotation = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (state !=State.isAlive)
        {
            return;
        }
        if (collision.gameObject.tag == "Friendly")
        { }
       
        else if (collision.gameObject.tag == "Finish")
        {
            Engine.Stop();
            rocketAudio.Stop();
            state = State.trasending;
            rocketAudio.PlayOneShot(Win);
            WinParticle.Play();
            Invoke("LoadNextScene", 1f);
        }
        
        if (collision.gameObject.tag == "Untagged"&&RocketImmunity.VideoAd == false)
        {
            Engine.Stop();
            rocketAudio.Stop();
            state = State.dying;
            rocketAudio.PlayOneShot(Explosion);
            ExplosionParticle.Play();
            Invoke("LoadNewScene", 1f);
        }
    }
    
    private void LoadNextScene()
    {
        WinParticle.Stop();
       
            SceneManager.LoadScene(NextSceneLoad);
            if (NextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", NextSceneLoad);
            }
        
    }
    private  void LoadNewScene()
    {
        ExplosionParticle.Stop();
        Scene scene = SceneManager.GetActiveScene();        
         SceneManager.LoadScene(scene.buildIndex);
    }
   
    
}
