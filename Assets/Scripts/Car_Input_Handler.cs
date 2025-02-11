using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Input_Handler : MonoBehaviour
{
    Car_Controller car_controller;

    private void Awake()
    {
        car_controller = GetComponent<Car_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        car_controller.SetInputVector(inputVector);
    }
}
