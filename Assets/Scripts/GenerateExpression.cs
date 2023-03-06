using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GenerateExpression : MonoBehaviour
{
    
    public int minNumber = 1;
    public int maxNumber = 10;
    public string[] operators = { "+", "-", "*", "/" };
    public TMP_Text expressionText;


    private System.Random random;

    void Start()
    {
        random = new System.Random();
        string expression = GenerateMathExpression();
        //Debug.Log(expression);
        expressionText.text = expression + " = ?";
    }

    string GenerateMathExpression()
    {
        int num1 = random.Next(minNumber, maxNumber + 1);
        string op1 = operators[random.Next(operators.Length)];
        int num2 = random.Next(minNumber, maxNumber + 1);
        string op2 = operators[random.Next(operators.Length)];
        int num3 = random.Next(minNumber, maxNumber + 1);

        string expression = num1 + " " + op1 + " " + num2 + " " + op2 + " " + num3;
        return expression;
    }

  
}

