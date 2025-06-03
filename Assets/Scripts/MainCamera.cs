using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // The object to follow (e.g., player)
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Camera offset from the target
    public float smoothSpeed = 0.125f; // Smooth movement speed

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
        transform.LookAt(target); // Optional: Make the camera look at the target
    }
}

