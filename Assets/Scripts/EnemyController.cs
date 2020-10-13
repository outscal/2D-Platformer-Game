using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject?.GetComponent<Player>();
        if (player != null)
        {
            
            player.OnDeath();
        }
    }
}
