using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float xOffset;
    public float yOffset;
    public Transform player;

    private void Update()
    {
            transform.position = new Vector3(player.position.x + xOffset, player.position.y + yOffset, transform.position.z);
            
    }
}
