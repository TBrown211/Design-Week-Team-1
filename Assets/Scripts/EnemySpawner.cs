using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Enemy prefab
    public GameObject enemyPrefab;

    // Spawning timer
    public float spawnTimer = 1f;
    public float spawnTimerReset = 5f;
    public float spawnTimerMultiplier = 1f;
    public int maxEnemyAmt = 5;
    public int currentEnemyAmt;

    public Camera cam;
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        // Get the mouse posistion
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Spawning at an interval
        if (spawnTimer <= 0 && currentEnemyAmt < maxEnemyAmt)
        {
            // Random amount and random spots
            int amountToSpawn = Random.Range(1, 4);

            for (int i = 0; i < amountToSpawn; i++)
            {
                // Generate a random position
                // TODO: Need non-hardcoded ranges
                // TODO: Not spawn on the player
                Vector2 randomPosition = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));

                // Create the enemy
                GameObject newEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
                newEnemy.transform.parent = transform;

                // Increase enemy amount counter
                currentEnemyAmt += 1;
            }

            // Reset timer
            spawnTimer = spawnTimerReset;
        }
        else // Count to next enemy spawn
        {
            spawnTimer -= 1 * spawnTimerMultiplier * Time.deltaTime;
        }
        

        // Debug spawning
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject newEnemy = Instantiate(enemyPrefab, mousePos, Quaternion.identity);
            newEnemy.transform.parent = transform;

            currentEnemyAmt += 1;
        }
    }

    public void DestroyEnemy()
    {
        // Reduce amount of enemy counter when one is destroyed
        currentEnemyAmt -= 1;
    }
}
