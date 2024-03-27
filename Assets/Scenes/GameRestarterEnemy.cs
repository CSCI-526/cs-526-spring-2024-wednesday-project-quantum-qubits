using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Analytics;


public class GameRestarterEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player") && other.gameObject.layer != LayerMask.NameToLayer("GhostPlayer"))
        {
            RestartGame1();
        }
    }

    // Update is called once per frame
    void RestartGame1()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
