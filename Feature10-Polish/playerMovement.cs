using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public Animator animator;

    public GameObject theNpc;

    private Rigidbody2D rb2d;

    public float speed;
    public float jump;
    public static int Health = 3;
    public GameOverController gameOverController;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        
    }

    void TakeDamage(int amount)
    {
        Health -= amount;

        if (Health < 0)
        {
            theNpc.GetComponent<Animator>().Play("Player_Death");
        }
    }  
    public void PickUpKey()
    {
        Debug.Log (" Key Destroyed ");
    }

    public void KillPlayer()
    {
        Debug.Log(" Player Dead");
        theNpc.GetComponent<Animator>().Play("Player_Death");
        gameOverController.playerDie();
        this.enabled = false;
    }


    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float verticle = Input.GetAxisRaw("Jump");

        MoveCharacter(horizontal, verticle);
        PlayMovementAnimation(horizontal, verticle);


    }

    private void MoveCharacter(float horizontal, float verticle)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        if (verticle > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }

    private void PlayMovementAnimation(float horizontal, float verticle)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }

        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //jump
        if (verticle > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        //crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            theNpc.GetComponent<Animator>().Play("Player_Crouch");
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            theNpc.GetComponent<Animator>().Play("Player_Idle");
        }
    }
}


