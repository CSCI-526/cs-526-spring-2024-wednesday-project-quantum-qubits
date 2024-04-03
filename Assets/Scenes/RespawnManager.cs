using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static Vector3 RespawnPoint;
    public static bool ShouldRespawn = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Keep this object and its data across scene reloads
    }
}