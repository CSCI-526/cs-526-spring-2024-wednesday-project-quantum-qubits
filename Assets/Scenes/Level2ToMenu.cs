using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Analytics;
using UnityEngine;

public class Level2To3 : MonoBehaviour
{

    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Trigger interaction with " + other.gameObject.tag);
        if (other.CompareTag("Player"))
        {
            
            SceneManager.LoadScene("Level3"); // Replace "Scene2Name" with the actual name of your Scene 2

            string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfdji8CdwfD0zEitXGcs9aKSgTElXx9be91O2GoFA4cC7MS1Q/formResponse";
            WWWForm form = new WWWForm();
            form.AddField("entry.304903029", AnalyticsSessionInfo.sessionId.ToString());
            form.AddField("entry.672846850", "Win - Level 2");
            UnityWebRequest www = UnityWebRequest.Post(URL, form);
            yield return www.SendWebRequest();
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
