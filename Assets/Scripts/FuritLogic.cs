using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuritLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If fruit spawns in something, respawn it somewhere else
        if (collision.gameObject.tag == "Border")
        {
            GameObject.Find("FruitSpawner").GetComponent<FruitSpawner>().SpawnFruit();
            Destroy(gameObject);
        }

        // When player touches fruit, add points and spawn another fruit somewhere else
        if (collision.gameObject.tag == "Player")
        {
            ScoreTracker.instance.AddPoint();
            GameObject.Find("FruitSpawner").GetComponent<FruitSpawner>().SpawnFruit();
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // If fruit spawns in something, respawn it somewhere else
        if (collision.gameObject.tag == "FruitNoSpawn")
        {
            GameObject.Find("FruitSpawner").GetComponent<FruitSpawner>().SpawnFruit();
            Debug.Log("Spawn in something");
            Destroy(gameObject);
        }
    }
}
