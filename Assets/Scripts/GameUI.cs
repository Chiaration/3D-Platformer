﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public TextMeshProUGUI scoreText;
    public GameObject endScreen;
    public TextMeshProUGUI endScreenHeader;
    public TextMeshProUGUI endScreenScoreText;

    public GameObject pauseScreen;

    public static GameUI instance;

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + GameManager.instance.score;
    }

    public void SetEndScreen(bool hasWon)
    {
        endScreen.SetActive(true);

        endScreenScoreText.text = "<b>Score</b>\n" + GameManager.instance.score;

        if (hasWon)
        {
            endScreenHeader.text = "Great work!";
            endScreenHeader.color = Color.green;
        }
        else
        {
            endScreenHeader.text = "Game Over!";
            endScreenHeader.color = Color.red;
        }
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void onMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    
    public void TogglePauseScreen(bool paused)
    {
        pauseScreen.SetActive(paused);
    }

    public void OnResumeButton()
    {
        GameManager.instance.TogglePauseGame();
    }
}