using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightPlayer : MonoBehaviour
{
    
    public Color newColor = Color.red; 

    private Color originalColor = Color.green;
    private int originalLayer; // To store the player's original layer
    public string passThroughLayerName = "GhostPlayer";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Make sure the player has the tag "Player"
        {
            SpriteRenderer playerSprite = other.gameObject.GetComponent<SpriteRenderer>();
            if (playerSprite != null)
            {
                playerSprite.color = newColor; // Change the player's color
                originalLayer = other.gameObject.layer;
                other.gameObject.layer = LayerMask.NameToLayer(passThroughLayerName);
            }
        }
    }
     private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SpriteRenderer playerSprite = other.gameObject.GetComponent<SpriteRenderer>();
            if (playerSprite != null)
            {
                // Change the color back to the original color
                playerSprite.color = originalColor;
                other.gameObject.layer = originalLayer;
            }
        }
    }
}
