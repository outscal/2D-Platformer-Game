using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<playerMovement>() != null)
        {
            playerMovement PlayerMovement = collision.gameObject.GetComponent<playerMovement>();
            PlayerMovement.PickUpKey();
            Destroy(gameObject);
        }
    }
}
