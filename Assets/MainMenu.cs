using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayLevel1Game()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void PlayLevel2Game()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void PlayLevel3Game()
    {
        SceneManager.LoadSceneAsync(3);
    }

}
