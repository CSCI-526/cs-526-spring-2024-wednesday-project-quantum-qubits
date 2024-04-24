using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformMover : MonoBehaviour
{
    public float speed = 3.0f;        // Speed of the movement
    public float movementDistance = 5.0f; // Distance the platform moves left and right

    private Vector3 startingPosition; // Initial position of the platform

    void Start()
    {
        startingPosition = transform.position; // Store the starting position
    }

    void Update()
    {
        Vector3 v = startingPosition;
        v.x += Mathf.Sin(Time.time * speed) * movementDistance; // Calculate the new X position
        transform.position = v; // Update the position
    }
}
