using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Data;

public class EvaluateExpression : MonoBehaviour
{
    public GenerateExpression generateExpression;
    private TMP_Text childText;
    private System.Random random;
    
    public Transform[] childObjects;
    public int indexTrueCell;
    
    void Start()
    {
        random = new System.Random();

        string expression = generateExpression.expression;
        //Debug.Log(expression);

        int result = EvaluateMathExpression(expression);
        AssignRandomCells(result);
    }

    void AssignRandomCells(int result){
        
        // Get the number of child objects 
        int numChildObjects = transform.childCount; 

        // Initialize the childObjects array with the correct size 
        childObjects = new Transform[numChildObjects]; 

        // Loop through each child object and add it to the array 
        for (int i = 0; i < numChildObjects; i++) { 
            childObjects[i] = transform.GetChild(i);

            childText = childObjects[i].GetComponent<TMP_Text>();

            if (childText != null) {

                int minValue = result-10;
                int maxValue = result+10;

                int randomValue = random.Next(minValue, maxValue+1);
                childText.text = randomValue.ToString();
            }
        } 

        indexTrueCell = random.Next(0, numChildObjects);
        childText = childObjects[indexTrueCell].GetComponent<TMP_Text>();
        childText.text =  result.ToString();

    } 

    public int EvaluateMathExpression(string expression)
    {
        DataTable dataTable = new DataTable();
        int result = Convert.ToInt32(dataTable.Compute(expression, null));
        return result;
    }

}
