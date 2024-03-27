using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEaten : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject.layer == LayerMask.NameToLayer("GhostPlayer"))
        {
            // If the colliding GameObject is the player and they're in GhostPlayer mode, destroy this enemy.
            Destroy(gameObject);
        }
    }
}
