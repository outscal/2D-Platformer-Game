using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_controller>() != null)
        {
            Player_controller playercontroller = collision.gameObject.GetComponent<Player_controller>();
            playercontroller.PickUpKey();
            Destroy(gameObject);
        }
    }
}
