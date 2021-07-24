using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keycontroller : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<playercontrolnew>() != null)
        {
            playercontrolnew playercontrolnew = collision.gameObject.GetComponent<playercontrolnew>();
            playercontrolnew.pickupKey();
            Destroy(gameObject);
        }
    }

}
