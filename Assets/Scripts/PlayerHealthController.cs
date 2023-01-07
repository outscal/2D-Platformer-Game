using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    public int playerHealth;
    public int maxHealth;
    public PlayerController playerController;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        playerHealth = maxHealth;
    }

   public void TakeDamage(int amount)                  // amount = how much damage player takes
   {
        playerHealth -= amount;
        if(playerHealth <= 0)                          // if the damage takes the player down to zero or 
        {    
            animator.SetTrigger("Death");
            spriteRenderer.enabled = false;            // below, then player will be destroyed
            playerController.enabled = false;
            
            //Destroy(gameObject, 1f);               //Commented destroy function bcoz destroying player
                                                      //gameobject is not a good practice.
            playerController.KillPlayer();
        }
   }
}
