using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Making a separate script for enemy damage to the player
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerHealthController>() != null)
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
