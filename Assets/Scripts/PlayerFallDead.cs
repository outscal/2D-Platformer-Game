﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerFallDead : MonoBehaviour
{
    public GameOverController gameoverController;
    public Animator animator;
    
    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                Debug.Log("Player Fall Dead");
                animator.SetBool("Death", true);
                StartCoroutine(DelayDeathAnimation());
                gameoverController.PlayeDied();
            }
            else
            {
                animator.SetBool("Death", false);
            }
        }

     IEnumerator DelayDeathAnimation()
    {
        // Delay before starting the death animation
        yield return new WaitForSeconds(4);

        // Play the death animation here
        // ...
    }
}
