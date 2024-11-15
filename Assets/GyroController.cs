using UnityEngine;

public class GyroSimulator : MonoBehaviour
{
    private Quaternion simulatedGyro;
    private Vector3 acceleration = Vector3.zero; // Acceleration vector
    public float accelerationFactor = 20.0f; // Adjust this value to control the speed of acceleration

    void Start()
    {
        Input.gyro.enabled = true; // Enable gyroscope (if running on a mobile device)
        simulatedGyro = Quaternion.identity;
    }

    void Update()
    {
        Vector3 direction;

#if UNITY_EDITOR
        // Use keyboard or mouse input to simulate rotation for testing
        float rotationSpeed = 100.0f;
        float rotateX = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        float rotateY = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
        simulatedGyro *= Quaternion.Euler(rotateY, rotateX, 0);

        // Derive acceleration from simulated gyro's forward direction
        direction = simulatedGyro * Vector3.forward;
#else
        // Use actual gyroscope data on a mobile device
        direction = Input.gyro.attitude * Vector3.forward;
#endif

        // Use the direction's x and z components to apply acceleration
        acceleration = new Vector3(direction.x, 0, direction.z) * accelerationFactor;

        // Update the object's position
        transform.position += acceleration * Time.deltaTime;
    }
}
