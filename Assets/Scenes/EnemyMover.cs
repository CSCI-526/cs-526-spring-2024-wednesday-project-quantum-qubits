using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public Transform pointA; // Assign in inspector
    public Transform pointB; // Assign in inspector
    public float speed = 2.0f;
    private Vector3 nextPosition;

    void Start()
    {
        nextPosition = pointA.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, nextPosition) < 0.1f)
        {
            nextPosition = nextPosition == pointA.position ? pointB.position : pointA.position;
        }
        MoveObject();
    }

    void MoveObject()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
    }
}
