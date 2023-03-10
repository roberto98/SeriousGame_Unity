using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Data;
using System;
using Random = UnityEngine.Random;

public class GenerateExpression : MonoBehaviour
{
    public LevelManager levelManager;
    public TMP_Text expressionText;
    private string expression;
    public int intResult;

    void Start()
    {
        int currentLevel = levelManager.currentLevel;
        float result;

        do
        {
            expression = GenerateMathExpression(currentLevel);
            //Debug.Log(expression);

            result = EvaluateMathExpression(expression);
        }
        while (!Mathf.Approximately(result, Mathf.Round(result)));

        intResult = Mathf.RoundToInt(result);
        expressionText.text = expression + " = ?";
        Debug.Log("Result is: " + intResult);

    }

    public string GenerateMathExpression(int currentLevel)
    {
        int minNumber = 1;
        int maxNumber = 10 * currentLevel;

        int firstNumber = Random.Range(minNumber, maxNumber);
        int secondNumber = Random.Range(minNumber, maxNumber);
        int thirdNumber = Random.Range(minNumber, maxNumber);

        int operation1;
        int operation2;
        string expression = "";

        switch (currentLevel)
        {
            case 1:
                // Level 1: simple addition and subtraction
                operation1 = Random.Range(1, 3);
                if (operation1 == 1)
                {
                    expression += firstNumber + " + ";
                }
                else
                {
                    expression += firstNumber + " - ";
                }
                expression += secondNumber;
                break;
            case 2:
                // Level 2: addition, subtraction, and multiplication
                operation1 = Random.Range(1, 4);
                operation2 = Random.Range(1, 3);
                switch (operation1)
                {
                    case 1:
                        expression += firstNumber + " + ";
                        break;
                    case 2:
                        expression += firstNumber + " - ";
                        break;
                    case 3:
                        expression += firstNumber + " * ";
                        break;
                }
                expression += "(";
                if (operation2 == 1)
                {
                    expression += secondNumber + " + " + thirdNumber;
                }
                else
                {
                    expression += secondNumber + " - " + thirdNumber;
                }
                expression += ")";
                break;
            case 3:
                // Level 3: addition, subtraction, multiplication, and division
                operation1 = Random.Range(1, 5);
                operation2 = Random.Range(1, 4);
                switch (operation1)
                {
                    case 1:
                        expression += firstNumber + " + ";
                        break;
                    case 2:
                        expression += firstNumber + " - ";
                        break;
                    case 3:
                        expression += firstNumber + " * ";
                        break;
                    case 4:
                        expression += firstNumber + " / ";
                        break;
                }
                expression += "(";
                if (operation2 == 1)
                {
                    expression += secondNumber + " + " + thirdNumber;
                }
                else if (operation2 == 2)
                {
                    expression += secondNumber + " - " + thirdNumber;
                }
                else
                {
                    expression += secondNumber + " * " + thirdNumber;
                }
                expression += ")";
                break;
            case 4:
                // Level 4: complex expression with parentheses
                operation1 = Random.Range(1, 5);
                operation2 = Random.Range(1, 5);
                int operation3 = Random.Range(1, 3);
                switch (operation1)
                {
                    case 1:
                        expression += firstNumber + " + ";
                        break;
                    case 2:
                        expression += firstNumber + " - ";
                        break;
                    case 3:
                        expression += firstNumber + " * ";
                        break;
                    case 4:
                        expression += firstNumber + " / ";
                        break;
                }
                expression += "(";
                switch (operation2)
                {
                    case 1:
                        expression += secondNumber + " + " + thirdNumber;
                        break;
                    case 2:
                        expression += secondNumber + " - " + thirdNumber;
                        break;
                    case 3:
                        expression += secondNumber + " * " + thirdNumber;
                        break;
                    case 4:
                        expression += secondNumber + " / " + thirdNumber;
                        break;
                }
                expression += ")";
                if (operation3 == 1)
                {
                    expression = "(" + expression + ") * " + secondNumber;
                }
                else
                {
                    expression = "(" + expression + ") / " + secondNumber;
                }
                break;
            case 5:
                // Level 5: complex expression with multiple parentheses
                operation1 = Random.Range(1, 5);
                operation2 = Random.Range(1, 5);
                operation3 = Random.Range(1, 5);
                int operation4 = Random.Range(1, 3);
                switch (operation1)
                {
                    case 1:
                        expression += firstNumber + " + ";
                        break;
                    case 2:
                        expression += firstNumber + " - ";
                        break;
                    case 3:
                        expression += firstNumber + " * ";
                        break;
                    case 4:
                        expression += firstNumber + " / ";
                        break;
                }
                expression += "(";
                switch (operation2)
                {
                    case 1:
                        expression += secondNumber + " + ";
                        break;
                    case 2:
                        expression += secondNumber + " - ";
                        break;
                    case 3:
                        expression += secondNumber + " * ";
                        break;
                    case 4:
                        expression += secondNumber + " / ";
                        break;
                }
                expression += "(";
                switch (operation3)
                {
                    case 1:
                        expression += thirdNumber + " + " + firstNumber;
                        break;
                    case 2:
                        expression += thirdNumber + " - " + firstNumber;
                        break;
                    case 3:
                        expression += thirdNumber + " * " + firstNumber;
                        break;
                    case 4:
                        expression += thirdNumber + " / " + firstNumber;
                        break;
                }
                expression += ")";
                expression += ")";
                if (operation4 == 1)
                {
                    expression = "(" + expression + ") * " + thirdNumber;
                }
                else
                {
                    expression = "(" + expression + ") / " + thirdNumber;
                }
                break;
        }

        return expression;
    }


    public float EvaluateMathExpression(string expression)
    {
        DataTable dataTable = new DataTable();
        float result = Convert.ToSingle(dataTable.Compute(expression, null));
        return result;
    }


}

