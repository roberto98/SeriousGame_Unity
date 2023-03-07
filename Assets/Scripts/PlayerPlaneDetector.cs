using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaneDetector : MonoBehaviour
{
    public GameObject plane;

    private BoxCollider planeCollider;

    private void Start()
    {
        planeCollider = plane.GetComponent<BoxCollider>();
        Debug.Log(planeCollider);
    }

    private void OnTriggerEnter(Collider other)
    {
         Debug.Log("Qui2");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Qui");
            if (planeCollider.bounds.Contains(other.transform.position))
            {
                Debug.Log("Player is in the area of the plane!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has left the area of the plane.");
        }
    }
}
