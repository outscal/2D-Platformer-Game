using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    //Player Health
    public int health;
    public int maxHealth = 3;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        //Player Health
        health = maxHealth;

    }

    // Update is called once per frame
    public void TakeDamage(int amount)
        {
        Debug.Log("player hit by the enemy");
            health -= amount;
            if (health <= 0)
            {
                playerController.KillPlayer();
            }
        }


 }
