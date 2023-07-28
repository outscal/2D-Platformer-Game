using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    //private void OnTriggerEnter2D(Collision2D collision)
    //{ 
    //    if(collision.gameObject.GetComponent<PlayerController>()!=null)
    //    {
    //        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
    //        playerController.PickUpKey();
    //        Destroy(gameObject);

    //    }    
        
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            playerController.PickUpKey();
            Destroy(gameObject);

        }

    }
}
