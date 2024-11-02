using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;  // The target that the camera follows
    public float smoothSpeed = 0.125f;  // Smoothness of the camera movement
    public Vector3 offset;  // Offset position of the camera relative to the target

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target);  // Optionally, make the camera look at the target
        }
    }
}
