using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelComplete2 : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    private void Awake()
    {
        isGameOver = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }
}
