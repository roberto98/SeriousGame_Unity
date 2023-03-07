using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // I show on the unity editor the variable to modify, and i keep it private so other classes cannot modify it
    [SerializeField] private float moveSpeed = 10f;
    private float raycastDistance = 0.5f;
    [SerializeField] private GameInput gameInput;

    private Vector3 lastInteractDir;
    private Rigidbody rb;

    void Start () {
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
        // Cast a ray in the movement direction to detect obstacles
        RaycastHit hit;
        if (Physics.Raycast(position, transform.forward, out hit, raycastDistance)) {
            if (hit.collider.CompareTag("Wall")) {
                return true;
            }
        }
        return false;
    }

    private void HandleMovement()
    {
        // Time.fixedDeltaTime is used for physics calculations
        float moveDistance = moveSpeed * Time.fixedDeltaTime;

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        // Position is vector3 (has x,y,z) so i've to cast my vector2 input
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);


        // Check for obstacles before moving the player
        if (!ObstacleInFront(transform.position + moveDir)) {
            // Move the player in the desired direction
            rb.MovePosition(transform.position + moveDir * moveDistance);
        }

        // I rotate the player visual according to the direction. Slerp let the movement smoother, according to deltaTime.
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

}
