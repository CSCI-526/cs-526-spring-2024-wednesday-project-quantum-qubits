using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level1ToLevel2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Trigger interaction with " + other.gameObject.tag);
        if (other.CompareTag("Player"))
        {
            // Debug.Log("Trigger interaction with111 " + other.name);
            SceneManager.LoadScene("Level2"); // Replace "Scene2Name" with the actual name of your Scene 2
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
