using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Turret Base
    public Rigidbody2D rbBase;
    public Camera cam;

    // Car support(?)
    public Rigidbody2D rbCar;
    public Rigidbody2D rbTurret;

    public bool isGamepad;
    [SerializeField] private Vector2 aim;

    // Turret gun 
    Vector2 mousePos;
    private float angle;

    // Bullet spawning
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Shooting speed
    public float bulletForce = 20f;
    public float shotTimer = 0f;
    public float shotTimerReset = 0.5f;
    public float shootingMultiplier = 1f;

    // Update is called once per frame
    void Update()
    {
        // Get mouse position
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Firing input
        if ((Input.GetButton("Fire1") || Input.GetAxisRaw("Fire1Gamepad") > 0) && shotTimer <= 0)
        {
            Shoot();
            shotTimer = shotTimerReset;
        }
        else
        {
            // Countdown until next shot
            shotTimer -= 1 * shootingMultiplier * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        // Check which input to use
        if (isGamepad)
        {
            // Get gamepad look direction
            aim = new Vector2(Input.GetAxisRaw("GamepadX"), Input.GetAxisRaw("GamepadY"));
            angle = Mathf.Atan2(-aim.y, aim.x) * Mathf.Rad2Deg - 90f;

            // Set the look angle, don't reset when the joystick is still
            if (aim.y != 0 || aim.x != 0)
            {
                rbBase.rotation = angle;
            }
        }
        else
        {
            // Get mouse position
            Vector2 lookDir = mousePos - rbBase.position;
            angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

            // set the turret rotation
            rbBase.rotation = angle;
        }
    }

    private void LateUpdate()
    {
        // Attach turret to car
        rbBase.transform.position = Vector2.MoveTowards(rbCar.position, transform.position, 1000 * Time.deltaTime);
        rbTurret.transform.position = Vector2.MoveTowards(rbCar.position, transform.position, 1000 * Time.deltaTime);
    }

    void Shoot()
    {
        // Create bullet at correct point and with correct rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        bullet.transform.parent = transform;

        // Make the bullet move
        rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
