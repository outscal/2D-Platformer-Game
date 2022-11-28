//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PickupsController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerContrller = collision.gameObject.GetComponent<PlayerController>();
            playerContrller.PickupKey();
            Destroy(gameObject);
        }
    }
}
