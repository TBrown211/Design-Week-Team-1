using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Var
    public GameObject enemySpawnerObject;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // Get rid of the enemy when it gets hit by bullet and reduce the current amount of enemies counter by 1
            //enemySpawnerObject = collision.gameObject;
            //enemySpawnerObject.Find("Enemies").GetComponent<EnemySpawner>.DestroyEnemy();
            GameObject.Find("Enemies").GetComponent<EnemySpawner>().DestroyEnemy();
            Destroy(collision.gameObject);
        }

        // Get rid of bullet if it hits something
        Destroy(gameObject);
    }
}
