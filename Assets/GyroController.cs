using UnityEngine;

public class GyroSimulator : MonoBehaviour
{
    private Quaternion simulatedGyro;

    void Start()
    {
        Input.gyro.enabled = true; // Enable gyroscope (if running on a mobile device)
        simulatedGyro = Quaternion.identity;
    }

    void Update()
    {
        #if UNITY_EDITOR
        // Use keyboard or mouse input to simulate rotation for testing
        float rotationSpeed = 100.0f;
        float rotateX = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        float rotateY = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
        simulatedGyro *= Quaternion.Euler(rotateY, rotateX, 0);
        transform.rotation = simulatedGyro;
        #else
        // Use actual gyroscope data on a mobile device
        transform.rotation = Input.gyro.attitude;
        #endif
    }
}