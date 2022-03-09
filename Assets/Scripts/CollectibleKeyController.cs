using UnityEngine;

/// <summary>
/// This script is used for the implementation of collecting the Keys by the player
/// It calls a function from PlayerController Script to implement what happens after picking up the Key.
/// </summary>

public class CollectibleKeyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.CollectibleKey();
            Destroy(gameObject);
        }
    }
}
