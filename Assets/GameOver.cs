using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject levelCompleteMenu;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene(0);
            levelCompleteMenu.SetActive(true);
            Time.timeScale = 0;

        }
    }
}
