﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool paused;
    
    public int score;

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        Destroy(GameObject.Find("SoundController"), 2f);
    }

    private void Update()
    {
        GameUI.instance.UpdateScoreText();

        if (Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        paused = !paused;
        
        if (paused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        
        GameUI.instance.TogglePauseScreen(paused);
    }

    public void AddScore(int scoreToGive)
    {
        score += scoreToGive;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void LevelEnd()
    {
        WinGame();
    }

    public void WinGame()
    {
        GameUI.instance.SetEndScreen(true);
    }

    public void GameOver()
    {
        GameUI.instance.SetEndScreen(false);
    }
    
}
