using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour
{

    public float speed = 5.0f; // Movement speed
    public float distance = 10.0f; // Distance to move back and forth

    private Vector3 startPosition;
    private Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = startPosition + Vector3.right * (Mathf.Sin(Time.time * speed)+1) * distance;

        // Update the position of the object
        transform.position = newPosition;
    }
}
