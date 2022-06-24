using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();

    }

    
     private void OnCollisionEnter2D(Collision2D collision)
     {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
     }
         private void Die()
        {
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("death");
        }
        private void RestartLevel()
        {
             SceneManager.LoadScene("GameOver");
        }

        
    
    
}
