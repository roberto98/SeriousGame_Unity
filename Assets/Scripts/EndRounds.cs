using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndRounds : MonoBehaviour
{
    public EvaluateExpression evaluateExpression;
    public Timer timer;
    public Player player;
    public TMP_Text countdownLevel;
    private int trueCell;
    
    public float roundTimer = 5.0f;

    void Start(){
        trueCell = evaluateExpression.indexTrueCell;
    }

    void Update(){

        if(!timer.OnTime(timer.timeLeft)){

            if(player.playerInPlane){
                if(player.triggeredCell == trueCell){
                    // Player win -> go next level
                    roundTimer-=Time.deltaTime;
                    // Countdown before next Level
                    countdownLevel.text = "YOU WIN!\nNext round in...\n"+Mathf.RoundToInt(roundTimer).ToString();

                    if(roundTimer<=0){
                        SceneManager.LoadScene("GameScene");
                    }

                } else {
                    // Player lose -> Load scene GameOver
                    roundTimer-=Time.deltaTime;
                    countdownLevel.text = "YOU LOSE!\nBack to menu in...\n"+Mathf.RoundToInt(roundTimer).ToString();

                    if(roundTimer<=0){
                        SceneManager.LoadScene("MainMenuScene");
                    }
                }

            } else {
                Debug.Log("Game Over");
            }
        }


    }

    
}
