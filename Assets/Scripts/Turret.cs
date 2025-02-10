using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Turret Base
    public Rigidbody2D rb2d;
    public Camera cam;

    // Turret gun 
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        // Get mouse position
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        // Get look direction
        Vector2 lookDir = mousePos - rb2d.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = angle;
    }
}
