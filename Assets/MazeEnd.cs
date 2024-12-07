using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeEnd : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Scene scene = SceneManager.GetActiveScene();
        string name = scene.name;
        string[] currentLevel = name.Split(' ');
        int level = PlayerPrefs.GetInt("UnlockedLevel");
        if (int.Parse(currentLevel[1]) == level)
        {
            PlayerPrefs.SetInt("UnlockedLevel", level++);
            LevelComplete lc = gameObject.GetComponent<LevelComplete>();
            lc.Pause();
            // SceneManager.LoadScene("Main Menu");
        }
    }
}
