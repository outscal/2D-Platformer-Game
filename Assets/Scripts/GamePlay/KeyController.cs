using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            playerMovement.PickUpKey();
            Destroy(gameObject); 
        }
    }
}
