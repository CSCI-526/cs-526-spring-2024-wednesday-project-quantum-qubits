using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WiningScreenManager : MonoBehaviour
{
    private string currentLevel;
    void Start()
    {
        // Retrieve the current level name or index
        // Default to "Level1" if nothing is stored
        currentLevel = PlayerPrefs.GetString("CurrentLevel", "1");
    }
    public void LoadNextLevel()
    {
        // Logic to determine and load the next level
        // This is a simplified example assuming levels are named sequentially (Level1, Level2, etc.)
        int nextLevelIndex = int.Parse(currentLevel) + 1;
        Debug.Log(nextLevelIndex);
        SceneManager.LoadScene(nextLevelIndex);
    }
}
