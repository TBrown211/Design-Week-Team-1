using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    // Fruit prefab
    public GameObject fruit;
    public GameObject ground;

    // Mouse position for debug
    private Vector2 mousePos;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn 10 berries at the start of the game
        for (int i = 0; i < 10; i++)
        {
            SpawnFruit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug
        mousePos = mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.M))
        {
            GameObject.FindWithTag("Fruit").transform.position = mousePos;
        }
    }

    public void SpawnFruit()
    {
        // All calcs example:
        // (ground position) + (ground size) - (fruit size)  
        // Ground width
        float widthMin = ground.transform.position.x - ground.GetComponent<SpriteRenderer>().size.x / 2 + fruit.GetComponentInChildren<SpriteRenderer>().size.x;
        float widthMax = ground.transform.position.x + ground.GetComponent<SpriteRenderer>().size.x / 2 - fruit.GetComponentInChildren<SpriteRenderer>().size.x;
        // Ground height
        float heightMin = ground.transform.position.y - ground.GetComponent<SpriteRenderer>().size.y / 2 + fruit.GetComponentInChildren<SpriteRenderer>().size.y;
        float heightMax = ground.transform.position.y + ground.GetComponent<SpriteRenderer>().size.y / 2 - fruit.GetComponentInChildren<SpriteRenderer>().size.y;

        // Get random location
        Vector2 location = new Vector2(Random.Range(widthMin, widthMax), Random.Range(heightMin, heightMax));

        // Create the fruit
        GameObject newFruit = Instantiate(fruit, location, Quaternion.identity);
        newFruit.transform.parent = transform;
    }
}
