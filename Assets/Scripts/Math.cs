using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Math : MonoBehaviour
{
    
   public int minNumber = 1;
    public int maxNumber = 10;
    public string[] operators = { "+", "-", "*", "/" };
    public TMP_Text expressionText;
    //public Text resultText;

    private System.Random random;

    void Start()
    {
        random = new System.Random();
        string expression = GenerateMathExpression();
        Debug.Log(expression);
        expressionText.text = expression + " = ?";

        //float result = EvaluateMathExpression(expression);
        //resultText.text = "Result: " + result.ToString();
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
