using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Timer
    private float despawnTimer = 3f;

    public void Update()
    {
        // Get rid of bullet if it's life timer runs out
        if (despawnTimer < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            despawnTimer -= 1 * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // Get rid of the enemy when it gets hit by bullet and reduce the current amount of enemies counter by 1
            GameObject.Find("Enemies").GetComponent<EnemySpawner>().DestroyEnemy();
            Destroy(collision.gameObject);
        }

        // Get rid of bullet if it hits something
        Destroy(gameObject);
    }
}
