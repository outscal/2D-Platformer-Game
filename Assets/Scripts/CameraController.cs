using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Taking reference of the player transform.
    [SerializeField] private Transform playerTransform;


    // Update is called once per frame
    void Update()
    {
        var playerPosition = playerTransform.transform.position;
        var transform1 = transform;
        transform1.position = new Vector3(playerPosition.x, playerPosition.y, transform1.position.z);

    }
}
