using UnityEngine;

namespace Elle2D
{
    //this is camera script
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [Range(1, 10)]
        [SerializeField] private float smoothFactor;
        private void LateUpdate()
        {
            Follow();
        }
        void Follow()
        {
            Vector3 targetPosition = target.position + offset;
            Vector3 smoothPos = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.deltaTime);
            transform.position = smoothPos;

        }
    }
}