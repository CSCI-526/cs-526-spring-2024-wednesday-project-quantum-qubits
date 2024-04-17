using UnityEngine;
using TMPro; // Ensure this is included for TextMeshProUGUI
using UnityEngine.SceneManagement;


public class GameTimer : MonoBehaviour
{
    private TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI component
    private float remainingTime; // Time remaining for the countdown
    private bool isRunning = false;
    public int starttime;
    void Awake()
    {
        timerText = GetComponent<TextMeshProUGUI>(); // Automatically get the TextMeshProUGUI component on this GameObject
    }

    void Start()
    {
        // Initialize the timer with 60 seconds for the countdown
        StartTimer(starttime);
    }

    void Update()
    {
        if (isRunning)
        {
            // Subtract the elapsed time since the last frame, effectively counting down
            remainingTime -= Time.deltaTime;

            // Update the timer text with the formatted time
            string timeToDisplay = FormatTime(remainingTime);
            timerText.text = timeToDisplay;

            // Check if the countdown has reached or passed zero
            if (remainingTime <= 0)
            {
                StopTimer();
                timerText.text = "00:00";
                // Ensure the display shows zero when the countdown is over
                RestartScene();
            }
        }
    }

    void RestartScene()
    {
        // Get the current scene name using the SceneManager
        string sceneName = SceneManager.GetActiveScene().name;
        // Load the current scene again
        SceneManager.LoadScene(sceneName);
    }

    public void StartTimer(float seconds)
    {
        remainingTime = seconds;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    string FormatTime(float timeToFormat)
    {
        // Ensure we don't end up displaying negative time
        if (timeToFormat < 0)
        {
            timeToFormat = 0;
        }

        // Format the remaining time into minutes:seconds:milliseconds
        int minutes = (int)(timeToFormat / 60);
        int seconds = (int)(timeToFormat % 60);
        int milliseconds = (int)((timeToFormat * 1000) % 1000);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
