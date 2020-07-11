using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.PlayerDied();
        }
    }
}
