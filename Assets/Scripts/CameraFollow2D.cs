using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;          // Target to follow (usually the player)
    public float smoothSpeed = 0.125f; // Smoothness of the camera movement
    public Vector3 offset;            // Offset from the target position

    private void LateUpdate()
    {
        if (target != null)
        {
            // Desired position with offset
            Vector3 desiredPosition = target.position + offset;

            // Smoothly interpolate between the current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Set the camera's position
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }
}
