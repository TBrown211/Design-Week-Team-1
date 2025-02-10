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
        
    }
}
