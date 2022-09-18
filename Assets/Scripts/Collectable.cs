using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            playerController.PickUpKey();
            Destroy(this.gameObject);
        }
    }
}
