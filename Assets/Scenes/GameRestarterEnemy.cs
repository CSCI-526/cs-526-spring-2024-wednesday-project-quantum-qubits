using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Analytics;


public class GameRestarterEnemy : MonoBehaviour
{
    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player") && other.gameObject.layer != LayerMask.NameToLayer("GhostPlayer"))
        {
            return RestartGame1();
        }
        return null;
    }

    // Update is called once per frame
    IEnumerator RestartGame1()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfdji8CdwfD0zEitXGcs9aKSgTElXx9be91O2GoFA4cC7MS1Q/formResponse";
        WWWForm form = new WWWForm();
        form.AddField("entry.304903029", AnalyticsSessionInfo.sessionId.ToString());
        form.AddField("entry.672846850", "Died (Enemy) - " + SceneManager.GetActiveScene().name);
        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();
    }
}
