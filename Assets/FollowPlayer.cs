using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float verticalOffset = 0.4f; // Offset to adjust vertical position relative to the player
    public float horizontalOffset = 0.4f; // Offset to adjust horizontal position relative to the player
    public float depth = -5f; // Fixed depth value for the camera

    // Start is called before the first frame update
    void Start()
    {
        if (RespawnManager.ShouldRespawn)
        {
            player.transform.position = RespawnManager.RespawnPoint; // Move player to respawn point
            RespawnManager.ShouldRespawn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the player both horizontally and vertically
        transform.position = new Vector3(player.transform.position.x + horizontalOffset,
                                         player.transform.position.y + verticalOffset,
                                         depth);

        // Load the main scene when Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
