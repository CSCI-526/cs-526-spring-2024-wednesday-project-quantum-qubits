using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Analytics;
using UnityEngine;

public class Level2ToMenu : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Trigger interaction with " + other.gameObject.tag);
        if (other.CompareTag("Player"))
        {
            
            SceneManager.LoadScene("Menu"); // Replace "Scene2Name" with the actual name of your Scene 2
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
