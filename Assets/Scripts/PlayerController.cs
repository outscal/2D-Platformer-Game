using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    private BoxCollider2D PlayerCollider;
    private Rigidbody2D rb2d;
    private SpriteRenderer spr;


    public float speed;
    public float jump;



    private void Awake()
    {
        PlayerCollider = gameObject.GetComponent<BoxCollider2D>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        spr = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        PlayerMovementAnimation(horizontal, vertical);
        PlayerMovement(horizontal, vertical);
        PlayerCrouch();

    }



  
    private void PlayerCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetBool("isCrouch", true);
            Debug.Log("crouch true");
            PlayerCollider.size = spr.sprite.bounds.size;
            PlayerCollider.offset = spr.sprite.bounds.center;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            anim.SetBool("isCrouch", false);
            Debug.Log("crouch false");

        }

    }

    private void PlayerMovement(float horizontal, float vertical)
    {     
        // move Player Horizontally
        Vector2 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;


        //move Player vertically
        if(vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f,jump),  ForceMode2D.Force);
        }

    }

    private void PlayerMovementAnimation(float horizontal, float vertical)
    {
        anim.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector2 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //jump animation

        if (vertical > 0)
        {
            anim.SetBool("isJump", true);
        }
        else
        {
            anim.SetBool("isJump", false);
        }
    }
}
