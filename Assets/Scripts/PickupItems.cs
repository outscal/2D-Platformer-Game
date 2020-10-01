using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItems : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null) {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.pickUpKey();
            Destroy(gameObject);

        }
    }
}
