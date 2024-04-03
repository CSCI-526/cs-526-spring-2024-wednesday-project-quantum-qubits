using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Analytics;
public class MainMenu : MonoBehaviour
{
    public void PlayLevel1Game()
    {
        StartCoroutine(MarkOutOfSpotlight());
        SceneManager.LoadSceneAsync(1);
    }
    public void PlayLevel2Game()
    {
        StartCoroutine(MarkOutOfSpotlight());
        SceneManager.LoadSceneAsync(2);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void PlayLevel3Game()
    {
        StartCoroutine(MarkOutOfSpotlight());
        SceneManager.LoadSceneAsync(3);
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

}
