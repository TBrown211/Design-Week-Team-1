using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class Car_Controller : MonoBehaviour
{
    [Header("Car Settings")]
    public float driftFactor = 0.95f;
    public float accelerationFactor = 30f;
    public float turnFactor = 3.5f;
    public float maxSpeed = 20f;
    public float carMaxHealth = 100f;
    public float carCurrentHealth;

    //Local Variables 
    float acclerationInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;

    public float velocityVSUp = 0;

    //Components
    Rigidbody2D carRB2D;

    public Image healthbar;


    private void Awake()
    {
        carRB2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set the current health the the max health at the start of the level
        carCurrentHealth = carMaxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(20);
        }
    }

    void FixedUpdate()
    {

        // Makes sure that the current health can not go above the max heatlh
        if (carCurrentHealth >= carMaxHealth)
        {
            carCurrentHealth = carMaxHealth;
        }

        ApplyEngineForce();

        KillOrthogonaVelocity();

        ApplySteering();
    }

    void ApplyEngineForce()
    {
        //Caculate how much "forward" we are going in terms of the direction of our velocity
        velocityVSUp = Vector2.Dot(transform.up, carRB2D.velocity);

        //Limit so we cannot go faster than the max speed in "forward" direction
        if(velocityVSUp > maxSpeed && acclerationInput > 0 ) 
            return;

        //Limit so we cannot go faster than the 50% of max speed in the "reverse" direction
        if(velocityVSUp < -maxSpeed * 0.5f && acclerationInput < 0 )
            return;

        //Limit so that we cannot go any faster in any direction while accelerating
        if (carRB2D.velocity.sqrMagnitude > maxSpeed * maxSpeed && acclerationInput > 0)
            return;

        //Apply drag when there is no input so that the car slows down and stops when the player is not pressing the button
        if (acclerationInput == 0)
        {
            carRB2D.drag = Mathf.Lerp(carRB2D.drag, 3.0f, Time.fixedDeltaTime * 3);
        }
        else
        {
            carRB2D.drag = 0;
        }

        //Create force for the engine
        Vector2 engineForceVector = transform.up * acclerationInput * accelerationFactor;
        
        //Apply force and push the car forward
        carRB2D.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        //Limit the cars ability to steer while moving slowly
        float minSpeedBeforeAllowTurning = (carRB2D.velocity.magnitude /8);
        minSpeedBeforeAllowTurning = Mathf.Clamp01(minSpeedBeforeAllowTurning);

        //Update the rotation angle based on input
        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAllowTurning;

        //Apply steering by rotating the car object
        carRB2D.MoveRotation(rotationAngle);
    }

    void KillOrthogonaVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRB2D.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRB2D.velocity, transform.right);

        carRB2D.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        acclerationInput = inputVector.y;
    }

    public void TakeDamage(float damage)
    {
        carCurrentHealth -= damage;
        healthbar.fillAmount = carCurrentHealth / 100;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Emeny")
        {
            TakeDamage(15);
        }
    }


}
