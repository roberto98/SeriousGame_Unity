using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft = 10.0f; // The amount of time left, in seconds
    public TMP_Text timerText; // The text object that will display the timer
    public Player player;

    void Update()
    {
        timeLeft -= Time.deltaTime; // Decrement the time left by the time since the last frame
    
        if (timeLeft < 0)
        {   
            // Perform the actions you want to do at the end of the timer
            timerText.text = "";
            player.GetComponent<Player>().enabled = false; // disable GameInput script
        } else {
            // Update the text object with the current time left
            timerText.text = "Time left\n" + Mathf.RoundToInt(timeLeft).ToString();
            player.GetComponent<Player>().enabled = true; // enable GameInput script
        }

    }

    public bool OnTime(float timeLeft){
        return timeLeft>0;
    }
}
