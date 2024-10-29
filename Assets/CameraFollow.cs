using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform plane;       // Reference to the plane object
    public Vector3 offset = new Vector3(0, 5f, 0); // Offset distance from the plane

    void LateUpdate()
    {
        if (plane == null)
        {
            Debug.LogWarning("Plane reference is missing!");
            return;
        }

        // Position the camera relative to the plane's position plus a static offset
    transform.position = plane.position + plane.rotation * offset;

        // Make the camera look at the plane
        transform.LookAt(plane.position);
    }
}
