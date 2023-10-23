using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerController playerController = collision.gameObject.GetComponent<playerController>();
        if (playerController != null)
        {
            Destroy(gameObject);
            playerController.Collectable_PickedUp();

        }
    }
}
