using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class EndGameUI : MonoBehaviour
{
    public TMP_Text countdownMenu;    
    private float menuTimer = 5.0f;

    // Update is called once per frame
    void Update()
    {
        menuTimer-=Time.deltaTime;
        countdownMenu.text = "Back to Menu in...\n"+Mathf.RoundToInt(menuTimer).ToString();
        
        if(menuTimer<=0){
            SceneManager.LoadScene("MainMenuScene");               
        }
    }
}
