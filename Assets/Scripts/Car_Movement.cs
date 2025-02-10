using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Movement : MonoBehaviour
{
    [SerializeField]
    private float carSpeed;
    [SerializeField]
    private float carRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        bool moveCarForward = Input.GetKey(KeyCode.W);
        bool moveCarBack = Input.GetKey(KeyCode.S);
        bool turnCarRight = Input.GetKeyDown(KeyCode.D);
        bool turnCarLeft = Input.GetKeyDown(KeyCode.A);

        if (moveCarForward)
        {
            transform.position += transform.up * carSpeed * Time.deltaTime;
        }
        if (moveCarBack)
        {
            transform.position -= transform.up * carSpeed * Time.deltaTime;
        }
        if (turnCarLeft)
        {
            carRotation += 90 * Time.deltaTime;
        }
        if (turnCarRight)
        {
            carRotation -= 90 * Time.deltaTime;
        }

        transform.rotation = Quaternion.Euler(0,0,transform.rotation.eulerAngles.z + carRotation);
    }
}
