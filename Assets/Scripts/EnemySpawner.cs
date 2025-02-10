using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Enemy prefab
    public GameObject enemyPrefab;

    public Camera cam;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            GameObject newBrick = Instantiate(enemyPrefab, mousePos, Quaternion.identity);
        }
    }
}
