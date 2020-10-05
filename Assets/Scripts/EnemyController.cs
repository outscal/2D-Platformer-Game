using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    DeathCount dc;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null) {
            Debug.Log("You died");
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            pc.KillPlayer();
        }
    }
}
