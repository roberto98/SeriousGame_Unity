using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaneDetector : MonoBehaviour
{

    private bool playerInPlane = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInPlane = true;
            Debug.Log("Player entered the plane.");
            GetComponent<Renderer>().material.color = Color.black;
            // Add any actions you want to trigger when the player enters the plane
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInPlane = false;
            Debug.Log("Player left the plane.");
            GetComponent<Renderer>().material.color = Color.green;
            // Add any actions you want to trigger when the player leaves the plane
        }
    }
}
