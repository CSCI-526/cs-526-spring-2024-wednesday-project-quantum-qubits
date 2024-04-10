using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (RespawnManager.ShouldRespawn)
            {
                player.transform.position = RespawnManager.RespawnPoint;; // Move player to respawn point
                RespawnManager.ShouldRespawn = false;
            }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x+0.4f, transform.position.y, -5);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
    
}
