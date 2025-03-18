using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float groundCheckDepth = 1;
    [SerializeField] private float sensorWidth = .5f;
    [SerializeField] private Vector2 sensorOffset;
    [SerializeField] private LayerMask groundMask;


    public bool isGrounded()
    {
        var leftRayhit = RayHit(Vector3.left, out Vector2? leftHitPoint, out Vector2? leftPoint);
        var rightRayhit = RayHit(Vector3.right, out Vector2? rightHitPoint, out Vector2? rightPoint);

        return leftRayhit || rightRayhit;
    }
    private bool RayHit(Vector3 dir, out Vector2? hitPoint, out Vector2? initPoint)
    {
        hitPoint = null;
        initPoint = null;

        var rayPosition = transform.position + (Vector3)sensorOffset - dir * sensorWidth;
        initPoint = rayPosition;
        var hit = Physics2D.Raycast(rayPosition, Vector3.down, groundCheckDepth, groundMask);

        if (hit.collider != null) {
            hitPoint = hit.point;
            return true;
        }
        
        return false;
    }

    private void OnDrawGizmos()
    {
        var leftRayhit = RayHit(Vector3.left, out Vector2? leftHitPoint, out Vector2? leftPoint);
        if (leftRayhit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine((Vector3)leftPoint, (Vector3)leftHitPoint);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine((Vector3)leftPoint, (Vector3)leftPoint + Vector3.down * groundCheckDepth);
        }

        var rightRayhit = RayHit(Vector3.right, out Vector2? rightHitPoint, out Vector2? rightPoint);
        if (rightRayhit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine((Vector3)rightPoint, (Vector3)rightHitPoint);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine((Vector3)rightPoint, (Vector3)rightPoint + Vector3.down * groundCheckDepth);
        }
    }

}
