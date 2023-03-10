using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Data;

public class InitializeCells : MonoBehaviour
{
    public GenerateExpression generateExpression;
    public Transform[] childObjects;

    private TMP_Text childText;
    private System.Random random;
    public int indexTrueCell;


    private void Start(){
        random = new System.Random();
        InitializingCells(generateExpression.intResult);
    }

    void InitializingCells(int result)
    {
        // Get the number of child objects 
        int numChildObjects = transform.childCount;

        // Initialize the childObjects array with the correct size 
        childObjects = new Transform[numChildObjects];

        // Loop through each child object and add it to the array 
        // numChildObjects-1 because the 5th child is the canvas and doesnt have renderer property
        for (int i = 0; i < numChildObjects; i++)
        {
            childObjects[i] = transform.GetChild(i);
            if(i < numChildObjects - 1)
            {
                childObjects[i].GetComponent<Renderer>().material.color = new Color32(98, 184, 245, 255);
            } else
            {
                AssignRandomCells(result, childObjects[i]);
            }      

        }
    }

    void AssignRandomCells(int result, Transform  canvasObject)
    {
        // Get the number of child objects 
        int numChildObjects = canvasObject.transform.childCount;
       

        // Initialize the childObjects array with the correct size 
        childObjects = new Transform[numChildObjects];

        // Used to check if the newly generated value is already in the set before assigning it
        HashSet<int> generatedValues = new HashSet<int>();
        generatedValues.Add(result);

        // Loop through each child object and add it to the array 
        for (int i = 0; i < numChildObjects; i++)
        {
            childObjects[i] = canvasObject.transform.GetChild(i);

            childText = childObjects[i].GetComponent<TMP_Text>();

            if (childText != null)
            {

                int minValue = result - 15;
                int maxValue = result + 15;

                // If the hashset contains the randomvalue generate a new one.
                int randomValue;
                do
                {
                    randomValue = random.Next(minValue, maxValue + 1);
                } while (generatedValues.Contains(randomValue));

                generatedValues.Add(randomValue);

                childText.text = randomValue.ToString();
            }
        }

        indexTrueCell = random.Next(0, numChildObjects);
        childText = childObjects[indexTrueCell].GetComponent<TMP_Text>();
        childText.text = result.ToString();

    }

}
