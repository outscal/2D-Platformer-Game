using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject target;
    [SerializeField]
    private Vector3 offset = new Vector3(0, 2, -10);

    public void FollowingPlayer(GameObject Player)
    {
        target = Player;      
    }

    private void LateUpdate()
    {
        transform.position = target.transform.position + offset;
    }
}
