using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Player position
    public GameObject player;

    // Enemy stats
    public float moveSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        // Get player position
        //Vector2 towardsPlayer = player.transform.position - transform.position;
        //Debug.Log(towardsPlayer);

        // Move towards player

    }
}
