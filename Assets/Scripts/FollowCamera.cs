using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform playerPos;

    private Vector3 velocity = Vector3.zero;
    void LateUpdate()
    {
        transform.position=Vector3.SmoothDamp(transform.position, 
                            new Vector3(playerPos.position.x,playerPos.position.y,-10f), ref velocity, 0.3f);
    }
}
