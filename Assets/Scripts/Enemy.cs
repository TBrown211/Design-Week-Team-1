using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    // Enemy stats
    private float moveSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        // Move towards player
        transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Car").transform.position, 
            1 * (moveSpeed + GameObject.Find("Car").GetComponent<Car_Controller>().velocityVSUp * 0.75f) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Enemy colliding with car
        if (collision.gameObject.name == "Car")
        {
            if (GameObject.Find("Car").GetComponent<Car_Controller>().velocityVSUp <= GameObject.Find("Car").GetComponent<Car_Controller>().maxSpeed / 2)
            {
                // Car takes damage if moving too slow
                GameObject.Find("Car").GetComponent<Car_Controller>().TakeDamage(5);
            }

            // Destroy enemy on roadkill
            GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().DestroyEnemy();
            Destroy(gameObject);
        }
    }
}
