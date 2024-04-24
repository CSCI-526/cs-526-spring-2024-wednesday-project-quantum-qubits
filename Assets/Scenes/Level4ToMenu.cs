using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Analytics;
using UnityEngine;

public class Level4ToMenu : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetString("CurrentLevel", "-1");
            Debug.Log(SceneManager.GetActiveScene().name);
            StartCoroutine(NextLevel());
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

    IEnumerator NextLevel() {
        SceneManager.LoadScene("WiningScene");
        RespawnManager.ShouldRespawn = false;
        string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfdji8CdwfD0zEitXGcs9aKSgTElXx9be91O2GoFA4cC7MS1Q/formResponse";
        WWWForm form = new WWWForm();
        form.AddField("entry.304903029", AnalyticsSessionInfo.sessionId.ToString());
        form.AddField("entry.672846850", "Win - Level 4");
        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();
    }
}
