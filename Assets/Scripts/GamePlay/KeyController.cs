using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerMovement = collision.gameObject.GetComponent<PlayerController>();
            playerMovement.PickUpKey();
            Destroy(gameObject); 
        }
    }
}
