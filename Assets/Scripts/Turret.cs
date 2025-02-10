using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Turret Base
    public Rigidbody2D rbBase;
    public Camera cam;

    // Turret gun 
    Vector2 mousePos;

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
        if (Input.GetButton("Fire1") && shotTimer <= 0)
        {
            Shoot();
            shotTimer = shotTimerReset;
        }
        else
        {
            shotTimer -= 1 * shootingMultiplier * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        // Get look direction
        Vector2 lookDir = mousePos - rbBase.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rbBase.rotation = angle;
    }

    void Shoot()
    {
        // Create bullet at correct point and with correct rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();

        // Make the bullet move
        rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
