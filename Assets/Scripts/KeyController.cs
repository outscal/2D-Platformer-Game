using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playercontroller = collision.gameObject.GetComponent<PlayerController>();
            Debug.Log(playercontroller);
            playercontroller.pickUpKey();
            Destroy(gameObject);
        }
    }
}
