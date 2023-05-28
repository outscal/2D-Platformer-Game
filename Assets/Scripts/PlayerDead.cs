using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Player Dead"); 
            animator.SetBool("Death", true);
        }
        else
        {
            animator.SetBool("Death", false);
        }

    }    




}
