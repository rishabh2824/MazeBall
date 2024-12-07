using UnityEngine;

public class GyroSimulator : MonoBehaviour
{
    private Quaternion simulatedGyro;
    private Rigidbody rb; // Rigidbody for physics-based movement
    public float accelerationFactor = 20.0f; // Controls the speed of the ball
    public float maxSpeed = 20.0f; // Maximum speed to cap ball movement

    void Start()
    {
        Input.gyro.enabled = true; // Enable gyroscope (if on a mobile device)
        simulatedGyro = Quaternion.identity;
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component

        // Check if Rigidbody exists
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing from the ball. Please add one to the GameObject.");
        }
    }

    void FixedUpdate()
    {
        Vector3 direction;

#if UNITY_EDITOR
        // Simulate rotation using keyboard input in the editor
        float rotationSpeed = 100.0f;
        float rotateX = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        float rotateY = Input.GetAxis("Vertical") * rotationSpeed * Time.fixedDeltaTime;
        simulatedGyro *= Quaternion.Euler(rotateY, rotateX, 0);

        // Derive direction from simulated gyro
        direction = simulatedGyro * Vector3.forward;
#else
        // Use actual gyroscope data on a mobile device
        direction = Input.gyro.attitude * Vector3.forward;
#endif

        // Calculate velocity based on gyro direction
        Vector3 targetVelocity = new Vector3(direction.x, 0, direction.z) * accelerationFactor;

        // Directly set the Rigidbody's velocity for immediate responsiveness
        if (rb != null)
        {
            rb.linearVelocity = Vector3.ClampMagnitude(targetVelocity, maxSpeed);
        }
    }
}
