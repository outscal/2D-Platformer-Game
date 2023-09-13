using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerController playerController = collision.gameObject.GetComponent<playerController>();
        if (playerController != null)
        {
            Destroy(gameObject);
            playerController.Collectable_PickedUp();
            
        }
    }
}
