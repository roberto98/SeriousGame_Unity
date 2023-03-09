using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int currentLevel = 1; // Starting level
    public int maxLevel = 5; // Maximum level

    // This method is called whenever the player completes a level
    public void LevelComplete()
    {
        if (currentLevel < maxLevel)
        {
            currentLevel++;
            PlayerPrefs.SetInt("currentLevel", currentLevel); // Save the current level as a player preference
            //Debug.Log("Level " + currentLevel + " complete!");
        }
        else
        {
            //Load Winner Scene
            SceneManager.LoadScene("FinishGame");
            //Debug.Log("You have reached the maximum level!");
        }
    }

    // This method is called whenever the game is over
    public void GameOver()
    {
        currentLevel = 1; // Reset the level to the starting level
        PlayerPrefs.SetInt("currentLevel", currentLevel); // Save the current level as a player preference
        //Debug.Log("Game Over! Level reset to " + currentLevel);
    }


    private void Start()
    {
        if (PlayerPrefs.HasKey("currentLevel")) // If the current level is stored as a player preference
        {
            currentLevel = PlayerPrefs.GetInt("currentLevel"); // Load the current level from the player preference
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("currentLevel", currentLevel); // Save the current level as a player preference when the game is closed
    }
}
