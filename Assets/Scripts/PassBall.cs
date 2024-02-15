using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassBall : MonoBehaviour
{
    public GameObject ballPrefab; // Assign this in the Inspector
    public Vector3 spawnPosition = new Vector3(1.858f, 0.854f, 1.593f);
    public Vector3 initialVelocity = new Vector3(-1f, 1f, 1f);
    public float spawnInterval = 3f; // Time in seconds between spawns

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval; // Schedule the first spawn
    }

    void Update()
    {
        // Check if it's time to spawn the next ball
        if (Time.time >= nextSpawnTime)
        {
            SpawnBall();
            nextSpawnTime = Time.time + spawnInterval; // Schedule the next spawn
        }
    }

    void SpawnBall()
    {
        // Instantiate the ball prefab at the specified position and with no rotation
        GameObject ball = Instantiate(ballPrefab, spawnPosition, Quaternion.identity);

        // Apply the initial velocity to the ball's Rigidbody
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = initialVelocity;
        }
        else
        {
            Debug.LogError("Ball prefab does not have a Rigidbody component.");
        }
    }


}
