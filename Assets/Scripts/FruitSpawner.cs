using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    // Fruit prefab
    public GameObject fruit;
    public GameObject ground;

    private int currentFruitAmt = 0;

    // Mouse position for debug
    private Vector2 mousePos;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn 10 berries at the start of the game
        SpawnFruit();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug
        /*mousePos = mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.M))
        {
            GameObject.FindWithTag("Fruit").transform.position = mousePos;
        }
        */

        if (currentFruitAmt <= 0)
        {
            SpawnFruit();
        }
    }

    public void SpawnFruit()
    {
        // Spawn all fruit
        GameObject[] fruitSpawnSpots = GameObject.FindGameObjectsWithTag("FruitSpawnSpot");

        for (int i = 0; i < fruitSpawnSpots.Length; i++)
        {
            GameObject newFruit = Instantiate(fruit, fruitSpawnSpots[i].transform.position, Quaternion.identity);
            newFruit.transform.parent = transform;
            currentFruitAmt++;
        }

        /*
        // All calcs example:
        // (ground position) + (ground size) - (fruit size)  
        // Ground width
        float widthMin = ground.transform.position.x - ground.GetComponent<SpriteRenderer>().size.x / 2;// + fruit.GetComponentInChildren<SpriteRenderer>().size.x;
        float widthMax = ground.transform.position.x + ground.GetComponent<SpriteRenderer>().size.x / 2;// - fruit.GetComponentInChildren<SpriteRenderer>().size.x;
        // Ground height
        float heightMin = ground.transform.position.y - ground.GetComponent<SpriteRenderer>().size.y / 2;// + fruit.GetComponentInChildren<SpriteRenderer>().size.y;
        float heightMax = ground.transform.position.y + ground.GetComponent<SpriteRenderer>().size.y / 2;// - fruit.GetComponentInChildren<SpriteRenderer>().size.y;

        
        GameObject[] invalidLocations = GameObject.FindGameObjectsWithTag("FruitNoSpawn");
        bool canSpawnHere = false;

        Vector2 location = Vector2.zero;
        // Create the fruit
        GameObject newFruit = Instantiate(fruit, location, Quaternion.identity);
        newFruit.transform.parent = transform;

        while (canSpawnHere == false)
        {
            // Get random location
            location = new Vector2(Random.Range(widthMin, widthMax), Random.Range(heightMin, heightMax));

            // Check over all other objects
            for (int i = 0;i < invalidLocations.Length;i++)
            {
                // Fruit is too close to something
                if (Vector2.Distance(location, invalidLocations[i].transform.position) > 10f)
                {
                    break;
                }
                canSpawnHere = true;
            }
        }
        
        newFruit.transform.position = location;

        // Get random location
        //Vector2 location = new Vector2(Random.Range(widthMin, widthMax), Random.Range(heightMin, heightMax));
        */
    }

    public void PlayerGotFruit()
    {
        currentFruitAmt -= 1;
    }
}
