using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int playerHealth;
    public int maxHealth;
    public PlayerController playerController;
    //public Animator animator;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        playerHealth = maxHealth;
    }

   public void TakeDamage(int amount)               // amount = how much damage player takes
   {
        playerHealth -= amount;
        if(playerHealth <= 0)                       // if the damage takes the player down to zero or 
        {    
            spriteRenderer.enabled = false;         // below, then player will be destroyed
            playerController.enabled = false;
            // animator.SetTrigger("Death");
            // Destroy(gameObject, 1f);  
            // playerController.ReloadLevel();
        }
   }
}
