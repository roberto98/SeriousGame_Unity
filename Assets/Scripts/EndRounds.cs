using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndRounds : MonoBehaviour
{
    //public PlayerPlaneDetector detectorCell;
    public EvaluateExpression evaluateExpression;
    public Timer timer;
    public Player player;

    void Start(){
        int trueCell = evaluateExpression.indexTrueCell;
        

    }

    void Update(){

        if(!timer.OnTime(timer.timeLeft)){

            if(player.playerInPlane){
                Debug.Log("check");
                // trueCell == player.triggeredCell 
            } else {
                Debug.Log("Game Over");
            }
        }

    }

    
}
