using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameObject player;
    void Awake() {
        player = GameObject.Find("Player");
        
    }
    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            RespawnManager.RespawnPoint = player.transform.position; // Set respawn point
            RespawnManager.ShouldRespawn = true; // Indicate that the player should respawn
            print("Checkpoint" + player.transform.position);
        }
        return null;
    }
}
