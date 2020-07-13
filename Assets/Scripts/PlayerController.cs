using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator anim;
    private BoxCollider2D PlayerCollider;
    private Rigidbody2D rb2d;
    private bool isGrounded;
    public float speed;
    public float jump;

    private void Awake()
    {
        PlayerCollider = gameObject.GetComponent<BoxCollider2D>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Pickupkey()
    {
        Debug.Log("Picked the key");
        scoreController.IncreaseScore(10);
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        PlayerMovementAnimation(horizontal);
        PlayerMovement(horizontal, vertical);
        PlayerCrouch();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
            isGrounded = false;
    }
    private void PlayerCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetBool("isCrouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            anim.SetBool("isCrouch", false);
        }
    }
    private void PlayerMovement(float horizontal, float vertical)
    {
        // move Player Horizontally
        if (!(anim.GetBool("isCrouch")))
        {
            Vector2 position = transform.position;
            position.x += horizontal * speed * Time.deltaTime;
            transform.position = position;
        }

        //move Player vertically and jump animation
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            anim.SetBool("isJump", true);
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("isJump", false);
        }
    }
    private void PlayerMovementAnimation(float horizontal)
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
    }
}
