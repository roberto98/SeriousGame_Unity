using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GenerateExpression : MonoBehaviour
{
    public int currentLevel = 0;
    public TMP_Text expressionText;


    private System.Random random;

    void Start()
    {
        random = new System.Random();
        string expression = GenerateMathExpression(currentLevel);
        expressionText.text = expression + " = ?";
    }

    public string GenerateMathExpression(int currentLevel)
    {
        Debug.Log("level: "+currentLevel);

        int minNumber, maxNumber;
        int num1, num2, num3;
        string op1, op2, expression;
        string[] operators = new string[] { "+", "-", "*", "/"};

        if(currentLevel==0){
            minNumber = 1;
            maxNumber = 10;
            /*
            Array.Resize(ref operators, operators.Length+2);
            operators[2]="*";
            operators[3]="/"; */
            num1 = random.Next(minNumber, maxNumber + 1);
            op1 = operators[random.Next(operators.Length)];
            num2 = random.Next(minNumber, maxNumber + 1);
            op2 = operators[random.Next(operators.Length)];
            num3 = random.Next(minNumber, maxNumber + 1);

            expression = num1 + " " + op1 + " " + num2 + " " + op2 + " " + num3;
        } else {
            minNumber = 1;
            maxNumber = 10;
        
            num1 = random.Next(minNumber, maxNumber + 1);
            op1 = operators[random.Next(operators.Length)];
            num2 = random.Next(minNumber, maxNumber + 1);
            op2 = operators[random.Next(operators.Length)];
            num3 = random.Next(minNumber, maxNumber + 1);

            expression = num1 + " " + op1 + " " + num2 + " " + op2 + " " + num3;
        }
        
        return expression;
    }

  
}

