using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // I show on the unity editor the variable to modify, and i keep it private so other classes cannot modify it
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
   // [SerializeField] private LayerMask countersLayerMask;

    private Vector3 lastInteractDir;

    // Update is called once per frame
    private void Update(){
        HandleMovement();
      //  HandleInteractions();
    }

    /*

    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        // I save last direction because i stop moving and i'm in front of the object, i still want to interact with it
        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask))
        {
            // Takes the type of component
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                // Has ClearCounter
                clearCounter.Interact();
               // if (baseCounter != selectedCounter)
               // {
               //     SetSelectedCounter(baseCounter);
               // }
            }
            else
            {
                //SetSelectedCounter(null);

            }
        }
        else
        {
            //SetSelectedCounter(null);
        }
    } */

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        // Position is vector3 (has x,y,z) so i've to cast my vector2 input
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;

        // In this way consider the player as a capsule and so non rischio che parte del corpo attraversi l'oggetto
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);
        
        if (!canMove)
        {
            // Cannot move towards moveDir

            // Attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = (moveDir.x < -.5f || moveDir.x > +.5f) && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                // Can move only on the X
                moveDir = moveDirX;
            }
            else
            {
                // Cannot move only on the X

                // Attempt only Z movement
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = (moveDir.z < -.5f || moveDir.z > +.5f) && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    // Can move only on the Z
                    moveDir = moveDirZ;
                }
                else
                {
                    // Cannot move in any direction
                }
            }
        } 

        if (canMove)
        {
            // I not assign, but i add otherwise the player will be always at the center position.
            // I multiply for deltaTime (that is the time between each frame) because i don't want that the player move faster according to the fps
            transform.position += moveDir * moveDistance;
        }

        // I rotate the player visual according to the direction. Slerp let the movement smoother, according to deltaTime.
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    /*
    private void SetSelectedCounter(BaseCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
        {
            selectedCounter = selectedCounter
        });
    }
    */



}
