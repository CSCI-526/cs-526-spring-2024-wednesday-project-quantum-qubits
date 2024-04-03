using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Analytics;

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
                StartCoroutine(MarkInSpotlight());
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
                StartCoroutine(MarkOutOfSpotlight());
            }
        }
    }
    IEnumerator MarkOutOfSpotlight()
    {
        string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfdji8CdwfD0zEitXGcs9aKSgTElXx9be91O2GoFA4cC7MS1Q/formResponse";
        WWWForm form = new WWWForm();
        form.AddField("entry.304903029", AnalyticsSessionInfo.sessionId.ToString());
        form.AddField("entry.672846850", "Out of Spotlight - " + SceneManager.GetActiveScene().name);
        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();
    }

    IEnumerator MarkInSpotlight()
    {
        string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfdji8CdwfD0zEitXGcs9aKSgTElXx9be91O2GoFA4cC7MS1Q/formResponse";
        WWWForm form = new WWWForm();
        form.AddField("entry.304903029", AnalyticsSessionInfo.sessionId.ToString());
        form.AddField("entry.672846850", "In Spotlight - " + SceneManager.GetActiveScene().name);
        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();
    }
}
