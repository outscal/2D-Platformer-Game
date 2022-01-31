using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    [SerializeField] private float maxHealth = 100f;

    public Slider healthBar;
    public static bool gameOver;

    private void Start()
    {
        health = maxHealth;
        healthBar.value = health;
        gameOver = false;
    }

    public void UpdateHealth(float mod)
    {
        health += mod;
        healthBar.value = health;

         if(health > maxHealth)
         {
            health = maxHealth;
         }
         else if (health <= 0f)
         {
            health = 0f;
            gameOver = true;
            // if (health == 0f)
            // {
            //     PlayerController playerController = gameObject.GetComponent<PlayerController>();
            //     playerController.KillPlayer();
            // }
            Debug.Log("Player Respawn");
         }
    }
}
