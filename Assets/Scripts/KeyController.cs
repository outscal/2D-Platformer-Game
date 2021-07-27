using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.pickUpkey();
            Destroy(gameObject);
        }
    }
}
