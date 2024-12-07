using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] GameObject levelCompleteMenu;
    public void Pause()
    {
        levelCompleteMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void GoHome()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
