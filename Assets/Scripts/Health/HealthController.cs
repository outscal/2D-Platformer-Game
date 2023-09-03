using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    private Animator animator;
    private bool dead;
    [SerializeField]private float startingHealth;
    [SerializeField] private float TimeDelay = 2f;
    public float currentHealth {get; private set; } 
    public GameOverController gameOverController;

    private void Awake()
    {
        currentHealth = startingHealth;
        animator = gameObject.GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if (currentHealth > 0)
        {
            Debug.Log(" Player Hurt By Enemy ");
            animator.SetTrigger("Hurt");
        }
        else
        {
            if(!dead)
            {
                Debug.Log(" Player Killed By Enemy ");
                animator.SetTrigger("Death");
                GetComponent<PlayerController>().enabled = false;
                dead = true;
                Invoke("Load_Scene" , TimeDelay);
            }
        }
    }

    private void Load_Scene()
    {
        Debug.Log(" Reloading Current Active Scene ");
        gameOverController.PlayerDied();
        GetComponent<PlayerController>().enabled = false;
    }


}
