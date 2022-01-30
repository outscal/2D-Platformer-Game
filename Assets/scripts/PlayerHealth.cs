using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float StartingHealth;
    public PlayerController playercontroller;
    private bool dead;

    public float CurrentHealth 
    { 
        get; 
        private set; 
    }

    private void Awake()
    {
        CurrentHealth = StartingHealth;
        playercontroller = GetComponent<PlayerController>();
    }

    private void TakeDamage(float _damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _damage, 0, StartingHealth);
        if (CurrentHealth > 0)
        {
            //hurt
            playercontroller.animator.SetTrigger("Hurt");

        }
        else
        {
            //ded
            if (!dead)
            {
                playercontroller.animator.SetTrigger("die");
                playercontroller.RB2D.bodyType = RigidbodyType2D.Static;
                dead = true;
            }
            
        }
    }
    
}
