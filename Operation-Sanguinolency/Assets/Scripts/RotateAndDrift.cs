using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndDrift : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float driftSpeed = -5f;
    public float slideSpeed = 1f;
    public float slideDeceleration = 2f; //new variable for slide deceleration
    public float lockedZPosition = 0f;

    private Vector3 lastMovementDirection = Vector3.zero;
    private float currentSlideSpeed = 0f; //new variable for current slide speed


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //rotate the object based on input
        transform.Rotate(verticalInput * rotationSpeed * Time.deltaTime, 0, -horizontalInput * rotationSpeed * Time.deltaTime);

        //calculate movement direction based on input
        Vector3 movementDirection = new Vector3(horizontalInput, verticalInput, 0).normalized;

        //apply sliding effect if object is moving
        if (movementDirection.magnitude > 0)
        {
            currentSlideSpeed = Mathf.Max(driftSpeed + slideSpeed, currentSlideSpeed); //get max slide speed

            //store last movement direction
            lastMovementDirection = movementDirection;
        }
        //apply sliding effect in the direction of last movement if object is not moving
        else if (lastMovementDirection.magnitude > 0)
        {
            //decrease slide speed gradually
            currentSlideSpeed = Mathf.Max(0f, currentSlideSpeed - slideDeceleration * Time.deltaTime);

            //apply slide effect
            transform.position += lastMovementDirection * currentSlideSpeed * Time.deltaTime;
        }

        //lock object to the specified Z position
        transform.position = new Vector3(transform.position.x, transform.position.y, lockedZPosition);
    }
}
