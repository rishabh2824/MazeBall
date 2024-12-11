using UnityEngine;

public class LoadMusic : MonoBehaviour
{
    private static LoadMusic instance;
    void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persist across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate instances
        }
    }
}
