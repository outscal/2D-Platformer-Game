using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private float attackDamage = 40f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;

    public void Update()
    {
        if(PlayerHealth.gameOver)
        {
            //animator.enabled = false;
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
        }

        canAttack += Time.deltaTime; 
           
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<PlayerController>().PlayerDamaged(attackDamage);
                canAttack= 0f;
            }
            // else
            // {
            //     canAttack += Time.deltaTime;
            // }
        }
    }

    // private void OnCollisionStay2D(Collision2D collision)
    // {
    //     if(collision.gameObject.GetComponent<PlayerController>() != null)
    //     {
    //         PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
    //         playerController.PlayerDamaged(-attackDamage);
    //     }
    // }
}
