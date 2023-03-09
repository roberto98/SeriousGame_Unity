using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{

    public static bool isGamePaused = false;
    public GameObject pausedMenuUI; // Update is called once per frame

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button quitButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            TogglePauseGame();
        }
    }

    public void TogglePauseGame() {
        isGamePaused = !isGamePaused;
        if (isGamePaused) {
            Time.timeScale = 0f;    
            pausedMenuUI.SetActive(true);  
        } else {
            Time.timeScale = 1f;
            pausedMenuUI.SetActive(false);
        }  
    }

    private void Awake(){
        resumeButton.onClick.AddListener(() =>
        {
            TogglePauseGame();
        });

        menuButton.onClick.AddListener(() =>
        {
            TogglePauseGame();
            SceneManager.LoadScene("MainMenuScene");
        });

        quitButton.onClick.AddListener(() =>
        {
            TogglePauseGame();
            Application.Quit();
        });

    }

}

