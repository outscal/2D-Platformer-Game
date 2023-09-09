using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<playerController>() != null)
        {
            playerController playerController = collision.gameObject.GetComponent<playerController>();
            playerController.Collectable_PickedUp();
            Destroy(gameObject);
        }
    }
}
