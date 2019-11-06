using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int scoreToGive)
    {
        score += scoreToGive;
    }

    public void LevelEnd()
    {
        //If last level
        if (SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex + 1)
        {
            WinGame();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void WinGame()
    {
        //Win Game
    }

    public void GameOver()
    {
        //Game Over
    }
}
