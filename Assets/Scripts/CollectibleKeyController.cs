using UnityEngine;

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
