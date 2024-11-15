using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody rb;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;

    // Speed at which the player moves.
    public float speed = 10.0f;

    // Gyroscope data for mobile movement
    private bool isGyroAvailable;
    private UnityEngine.Gyroscope gyro;

    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();

        // Check for and enable the gyroscope on mobile devices
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            isGyroAvailable = true;
        }
        else
        {
            isGyroAvailable = false;
        }
    }

    // This function is called when a move input is detected (for desktop WASD movement).
    void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate()
    {
        Vector3 movement;

        if (isGyroAvailable && Application.isMobilePlatform)
        {
            // Use gyroscope input for movement on mobile
            movement = new Vector3(gyro.attitude.y, 0.0f, -gyro.attitude.x);
        }
        else
        {
            // Use WASD input for movement on desktop
            movement = new Vector3(movementX, 0.0f, movementY);
        }

        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed);
    }
}
