﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject nextLevelButton;
    

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
        Time.timeScale = 0f;
        endScreen.SetActive(true);

        endScreenScoreText.text = "<b>Score</b>\n" + GameManager.instance.score;

        if (hasWon)
        {
            nextLevelButton.SetActive(true);
            restartButton.SetActive(false);
            endScreenHeader.text = "Great work!";
            endScreenHeader.color = Color.green;
        }
        else
        {
            endScreenHeader.text = "Game Over!";
            endScreenHeader.color = Color.red;
            restartButton.SetActive(true);
            nextLevelButton.SetActive(false);
        }
    }

    public void OnRestartButton()
    {
        if (GameManager.instance.paused)
        {
            GameManager.instance.TogglePauseGame();
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.instance.ResetScore();
        Time.timeScale = 1f;
    }

    public void onMenuButton()
    {
        if (GameManager.instance.paused)
        {
            GameManager.instance.TogglePauseGame();
        }
        
        SceneManager.LoadScene(0);
        GameManager.instance.ResetScore();
        Time.timeScale = 1f;
    }
    
    public void TogglePauseScreen(bool paused)
    {
        pauseScreen.SetActive(paused);
    }

    public void OnResumeButton()
    {
        GameManager.instance.TogglePauseGame();
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.instance.ResetScore();
        Time.timeScale = 1f;
    }
}
