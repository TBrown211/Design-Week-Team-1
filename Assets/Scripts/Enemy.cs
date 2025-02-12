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
        transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Car").transform.position, 1 * moveSpeed * Time.deltaTime);
    }
}
