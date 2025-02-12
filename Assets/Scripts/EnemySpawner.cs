using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Enemy prefab
    public GameObject enemyPrefab;
    public GameObject player;

    // Spawning timer
    public float spawnTimer = 1f;
    public float spawnTimerReset = 5f;
    public float spawnTimerMultiplier = 1f;
    public int maxEnemyAmt = 20;
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
            int amountToSpawn = Random.Range(10, 21);

            for (int i = 0; i < amountToSpawn; i++)
            {
                // Generate a random position
                // TODO: Need non-hardcoded ranges
                // TODO: Not spawn on the player
                Vector2 randomPosition = SpawnRange();

                // Create the enemy
                GameObject newEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
                newEnemy.transform.parent = transform;

                // Increase enemy amount counter
                currentEnemyAmt += 1;
            }

            // Reset timer
            spawnTimer = Random.Range(3, 6);
        }
        else // Count to next enemy spawn
        {
            spawnTimer -= 1 * spawnTimerMultiplier * Time.deltaTime;
        }
        

        // Debug spawning
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject newEnemy = Instantiate(enemyPrefab, mousePos, Quaternion.identity);
            newEnemy.transform.parent = transform;

            currentEnemyAmt += 1;
        }
        */
    }

    public void DestroyEnemy()
    {
        // Reduce amount of enemy counter when one is destroyed
        currentEnemyAmt -= 1;
    }

    // Create a spawn range for the enemies
    public Vector2 SpawnRange()
    {
        Vector2 spawnPlace;
        Vector2 playerPos = player.transform.position;
        Vector2 randomDirection = Random.onUnitSphere;

        // Generate random sport to spawn the enemy
        // Trying to keep it offscreen by adding the car's current velocity
        spawnPlace = playerPos + randomDirection * (20 + GameObject.Find("Car").GetComponent<Car_Controller>().velocityVSUp);

        return spawnPlace;
    }
}
