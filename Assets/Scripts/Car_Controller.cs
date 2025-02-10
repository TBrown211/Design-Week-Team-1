using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Car_Controller : MonoBehaviour
{
    [Header("Car Settings")]
    public float accelerationFactor = 30f;
    public float turnFactor = 3.5f;

    //Local Variables 
    float acclerationInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;

    //Components
    Rigidbody2D carRB2D;


    private void Awake()
    {
        carRB2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        ApplyEngineForce();

        ApplySteering();
    }

    void ApplyEngineForce()
    {
        //Create force for the engine
        Vector2 engineForceVector = transform.up * acclerationInput * accelerationFactor;
        
        //Apply force and push the car forward
        carRB2D.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        //Update the rotation angle based on input
        rotationAngle -= steeringInput * turnFactor;

        //Apply steering by rotating the car object
        carRB2D.MoveRotation(rotationAngle);
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        acclerationInput += inputVector.y;
    }
}
