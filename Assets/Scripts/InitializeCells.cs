using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeCells : MonoBehaviour
{
    public Transform[] childObjects;

    private void Start(){
        

        // Get the number of child objects 
        int numChildObjects = transform.childCount; 

        // Initialize the childObjects array with the correct size 
        childObjects = new Transform[numChildObjects]; 

        // Loop through each child object and add it to the array 
        // numChildObjects-1 because the 5th child is the canvas and doesnt have renderer property
        for (int i = 0; i < numChildObjects-1; i++) { 
            childObjects[i] = transform.GetChild(i);
            childObjects[i].GetComponent<Renderer>().material.color = new Color32(98, 184, 245, 255);
        }
    }
}
