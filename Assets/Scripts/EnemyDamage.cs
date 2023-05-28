using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Making a separate script for enemy damage to the player
    [SerializeField] private int damage;

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerHealthController>() != null)
        {
            // Fetch the PlayerHealthController object
            PlayerHealthController playerHealthController = collision.gameObject.GetComponent<PlayerHealthController>();  
            playerHealthController.TakeDamage(damage);
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealthController>() != null)
        {
            // Fetch the PlayerHealthController object
            PlayerHealthController playerHealthController = collision.gameObject.GetComponent<PlayerHealthController>();
            playerHealthController.TakeDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
