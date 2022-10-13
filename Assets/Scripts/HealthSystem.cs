using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public int maxHealth = 3;
    public int currentHealth;
    GameOverController gameOverController;

    Animator anim;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        currentHealth = maxHealth;
        gameOverController = gameObject.GetComponent<GameOverController>();
    }


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            anim.SetBool("isDead", true);
            OnPlayerDeath?.Invoke();
        }
    }
}
