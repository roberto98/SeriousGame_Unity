using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndRounds : MonoBehaviour
{
    public GenerateExpression generateExpression;
    public InitializeCells initializeCells;
    public SoundsController soundsController;
    public Timer timer;
    public Player player;
    public TMP_Text countdownLevel;
    private int trueCell;
    public LevelManager levelManager;

    public float roundTimer = 5.0f;
    private bool hasPlayedSound = false;
    
    void Start(){
        trueCell = initializeCells.indexTrueCell;
    }

    void Update(){

        if(!timer.OnTime(timer.timeLeft)){

            if(player.playerInPlane){
                if(player.triggeredCell == trueCell){ // Player win -> go next level
                    
                    roundTimer-=Time.deltaTime;

                    // Countdown before next Level
                    countdownLevel.text = "CORRECT!\nNext round in...\n"+Mathf.RoundToInt(roundTimer).ToString();

                    if (!hasPlayedSound) {
                        soundsController.PlayWin();
                        hasPlayedSound = true;
                    }

                    if(roundTimer<=0){
                        levelManager.LevelComplete();                    
                    }

                } else { // Player lose -> Load scene GameOver
                    
                    roundTimer-=Time.deltaTime;
                    countdownLevel.text = "WRONG!\nBack to menu in...\n"+Mathf.RoundToInt(roundTimer).ToString();

                    if (!hasPlayedSound) {
                        soundsController.PlayLose();
                        hasPlayedSound = true;
                    }

                    if(roundTimer<=0){
                        levelManager.GameOver();
                    }
                }

            } else {
                    roundTimer-=Time.deltaTime;
                    countdownLevel.text = "WRONG!\nBack to menu in...\n"+Mathf.RoundToInt(roundTimer).ToString();

                    if (!hasPlayedSound) {
                        soundsController.PlayLose();
                        hasPlayedSound = true;
                    }

                    if(roundTimer<=0){
                        levelManager.GameOver();
                    }
                //Debug.Log("Game Over");
            }
        }


    }

    
}
