using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Analytics;


public class Level2ToLevel3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Trigger interaction with " + other.gameObject.tag);
        if (other.CompareTag("Player"))
        {
            // Debug.Log("Trigger interaction with111 " + other.name);
            StartCoroutine(Post("win2"));
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
    IEnumerator Post(string s1) {
            string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfdji8CdwfD0zEitXGcs9aKSgTElXx9be91O2GoFA4cC7MS1Q/formResponse";
            WWWForm form = new WWWForm();
            form.AddField("entry.304903029", AnalyticsSessionInfo.sessionId.ToString());
            form.AddField("entry.672846850", s1);
            UnityWebRequest www = UnityWebRequest.Post(URL, form);
            yield return www.SendWebRequest();
    }
}
