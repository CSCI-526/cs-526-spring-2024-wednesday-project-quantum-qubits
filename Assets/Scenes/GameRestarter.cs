using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Analytics;


public class GameRestarter : MonoBehaviour
{
    // private Vector3 respawnPoint;
    private GameObject player;
    void Awake() {
        player = GameObject.Find("Player");
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("hit");
            StartCoroutine(RestartGame());
        }
    }

    // Update is called once per frame
    IEnumerator RestartGame()
    {
        // Reload the current scene
        
            string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfdji8CdwfD0zEitXGcs9aKSgTElXx9be91O2GoFA4cC7MS1Q/formResponse";
            WWWForm form = new WWWForm();
            form.AddField("entry.304903029", AnalyticsSessionInfo.sessionId.ToString());
            form.AddField("entry.672846850", "Died (Spikes) - " + SceneManager.GetActiveScene().name);
            UnityWebRequest www = UnityWebRequest.Post(URL, form);
            yield return www.SendWebRequest();
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // Ensure the respawn logic works across scene reloads
            if (RespawnManager.ShouldRespawn)
            {
                player.transform.position = RespawnManager.RespawnPoint;; // Move player to respawn point
            }

    }
    // IEnumerator Post(string s1) {
    //         string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfdji8CdwfD0zEitXGcs9aKSgTElXx9be91O2GoFA4cC7MS1Q/formResponse";
    //         WWWForm form = new WWWForm();
    //         form.AddField("entry.304903029", AnalyticsSessionInfo.sessionId.ToString());
    //         form.AddField("entry.672846850", s1);
    //         UnityWebRequest www = UnityWebRequest.Post(URL, form);
    //         yield return www.SendWebRequest();
    // }
}
