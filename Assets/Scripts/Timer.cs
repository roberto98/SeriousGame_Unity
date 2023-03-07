using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft = 10.0f; // The amount of time left, in seconds
    public TMP_Text timerText; // The text object that will display the timer
    public GameObject planeObject;
    public GameObject playerObject;



    void Update()
    {
        timeLeft -= Time.deltaTime; // Decrement the time left by the time since the last frame

        if (timeLeft < 0)
        {   
            // Perform the actions you want to do at the end of the timer
            Debug.Log("Time's up!");
            // For example, you can load a new scene, display a game over screen, or restart the level
        }

        // Update the text object with the current time left
        timerText.text = "Timer\n" + Mathf.RoundToInt(timeLeft).ToString();
    }
}
