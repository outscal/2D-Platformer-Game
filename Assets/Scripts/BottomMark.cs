using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomMark : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {

            collision.gameObject.GetComponent<Player>().OnDeath(); 

        }
    }

}
