using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;

     private void Awake()
     {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 2);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            if (i < buttons.Length)
            {
                buttons[i].interactable = true;
            } else {
                break;
            }
        }
     }

    public void OpenLevel(int levelId)
    {
        string levelName = "Level " + levelId;
        SceneManager.LoadScene(levelName);
    }
}
