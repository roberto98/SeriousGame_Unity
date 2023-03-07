using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EvaluateExpression : MonoBehaviour
{

    public TMP_Text expressionText;
    private TMP_Text childText;

    private System.Random random;
    
    public Transform[] childObjects;


    void Start()
    {
        random = new System.Random();

        string expression =  expressionText.text;

        float result = EvaluateMathExpression(expression);
        AssignRandomCells(result);
    }

    void AssignRandomCells(float result){
        
        // Get the number of child objects 
        int numChildObjects = transform.childCount; 

        // Initialize the childObjects array with the correct size 
        childObjects = new Transform[numChildObjects]; 

        // Loop through each child object and add it to the array 
        for (int i = 0; i < numChildObjects; i++) { 
            childObjects[i] = transform.GetChild(i);

            childText = childObjects[i].GetComponent<TMP_Text>();

            if (childText != null) {

                float minValue = result-10;
                float maxValue = result+10;

                double randomValue = (float)(random.NextDouble() * (maxValue - minValue) + minValue);
                childText.text = randomValue.ToString();
            }
        } 

        int rand_cell = random.Next(0, numChildObjects);
        childText = childObjects[rand_cell].GetComponent<TMP_Text>();
        childText.text =  result.ToString();

    } 

    float EvaluateMathExpression(string expression)
    {
        string[] elements = expression.Split(' ');

        float num1 = float.Parse(elements[0]);
        string op1 = elements[1];
        float num2 = float.Parse(elements[2]);
        string op2 = elements[3];
        float num3 = float.Parse(elements[4]);

        float result = 0f;

        if (op1 == "+")
        {
            result = num1 + num2;
        }
        else if (op1 == "-")
        {
            result = num1 - num2;
        }
        else if (op1 == "*")
        {
            result = num1 * num2;
        }
        else if (op1 == "/")
        {
            result = num1 / num2;
        }

        if (op2 == "+")
        {
            result += num3;
        }
        else if (op2 == "-")
        {
            result -= num3;
        }
        else if (op2 == "*")
        {
            result *= num3;
        }
        else if (op2 == "/")
        {
            result /= num3;
        }

        return result;
    }
}
