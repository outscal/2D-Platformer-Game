using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;

    public void Update()
    {
        if(PlayerHealth.gameOver)
        {
            this.enabled = false;
        }
           
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack= 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if(collision.gameObject.GetComponent<PlayerController>() != null)
    //     {
    //         PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
    //         playerController.KillPlayer();
    //     }
    // }
}
