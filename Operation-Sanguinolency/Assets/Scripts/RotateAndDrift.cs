using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndDrift : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float driftSpeed = -5f;
    public float lockedZPosition = 0f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Rotate(verticalInput * rotationSpeed * Time.deltaTime, 0, -horizontalInput * rotationSpeed * Time.deltaTime);
        transform.position += new Vector3(horizontalInput * driftSpeed * Time.deltaTime, verticalInput * driftSpeed * Time.deltaTime, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y, lockedZPosition);
    }
}
