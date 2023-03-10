using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // I show on the unity editor the variable to modify, and i keep it private so other classes cannot modify it
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private GameInput gameInput;

    private Vector3 lastInteractDir;
    private Rigidbody rb;

    private void Start () {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update(){
        HandleMovement();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            rb.velocity = Vector3.zero;
        }
    }

    private bool ObstacleInFront(Vector3 position) {
        float radius = 0.7f; // Set the radius of the capsule
        float height = 2f; // Set the height of the capsule
        Vector3 direction = transform.forward; // Set the direction to cast the capsule
        float raycastDistance = 2f; // Set the maximum distance to cast the capsule
        int layerMask = LayerMask.GetMask("Wall"); // Set the layer mask to only detect walls

        // Cast a capsule in the movement direction to detect obstacles
        if (Physics.CapsuleCast(position + new Vector3(0, height / 2 - radius, 0), position + new Vector3(0, height / 2 + radius, 0), radius, direction, out RaycastHit hit, raycastDistance, layerMask))
        {
            return true;
        }
        return false;
    }

    private void HandleMovement() {
        // Time.fixedDeltaTime is used for physics calculations, we are using a rigid body
        float moveDistance = moveSpeed * Time.fixedDeltaTime;

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        // Position is vector3 (has x,y,z) so i've to cast my vector2 input
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        // Check for obstacles before moving the player
        bool canMove = !ObstacleInFront(transform.position + moveDir);

        if (!canMove){ // Cannot move towards moveDir
            // Attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = (moveDir.x < -.5f || moveDir.x > +.5f) && !ObstacleInFront(transform.position + moveDir);

            if (canMove) { // Can move only on the X
                
                moveDir = moveDirX;
            } else { // Cannot move only on the X
                // Attempt only Z movement
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = (moveDir.z < -.5f || moveDir.z > +.5f) && !ObstacleInFront(transform.position + moveDir);
                if (canMove) { // Can move only on the Z
                    moveDir = moveDirZ;
                } else {
                    // Cannot move in any direction
                }
            }
        }

        if (canMove) {
            // Move the player in the desired direction
            rb.MovePosition(transform.position + moveDir * moveDistance);
        }

        // I rotate the player visual according to the direction. Slerp let the movement smoother, according to deltaTime.
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }



    public int triggeredCell = -1; // -1 indicates no cell has been triggered
    public bool playerInPlane = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cell1"))
        {
            playerInPlane = true;
            other.GetComponent<Renderer>().material.color = new Color32(98, 104, 245, 100);
            triggeredCell = 0;
        }
        else if (other.CompareTag("Cell2"))
        {
            playerInPlane = true;
            other.GetComponent<Renderer>().material.color = new Color32(98, 104, 245, 100);
            triggeredCell = 1;
        }
        else if (other.CompareTag("Cell3"))
        {
            playerInPlane = true;
            other.GetComponent<Renderer>().material.color = new Color32(98, 104, 245, 100);
            triggeredCell = 2;
        }
        else if (other.CompareTag("Cell4"))
        {
            playerInPlane = true;
            other.GetComponent<Renderer>().material.color = new Color32(98, 104, 245, 100);
            triggeredCell = 3;
        }

        //Debug.Log("Player entered cell " + triggeredCell);
        
    }

    
    private void OnTriggerExit(Collider other)
    {
        playerInPlane = false;
        //Debug.Log("Player left the plane.");
        other.GetComponent<Renderer>().material.color =new Color32(98, 184, 245, 255); 
    }

}
