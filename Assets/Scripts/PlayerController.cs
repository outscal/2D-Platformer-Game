using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0,10)][SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    public Animator animator;
    Rigidbody2D rb2d;
    BoxCollider2D boxCollider;
    bool isGrounded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
        Debug.Log(isGrounded);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
        Debug.Log(isGrounded);
    }
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); 
        float crouch = Input.GetAxisRaw("Crouch");
        float jump = Input.GetAxisRaw("Jump");
        animator.SetBool("isGrounded", isGrounded);
        JumpAnimation(jump);
        MoveAnimation(horizontal);
        CrouchAnimation(crouch);
        PlayerMovement(horizontal,crouch,jump);
    }

    private void PlayerMovement(float horizontal,float crouch,float jump)
    {
        Vector3 playerPos = transform.position;
        if (crouch > 0)
        {
            playerPos.x += horizontal * moveSpeed * Time.deltaTime * 0.5f;
        }
        else
        {
            playerPos.x += horizontal * moveSpeed * Time.deltaTime;
        }
        transform.position = playerPos;

        if (jump > 0 && isGrounded)
        {
            rb2d.AddForce(new Vector2(0, jumpForce));
        }

    }

    private void CrouchAnimation(float crouch)
    {
        
        if (crouch > 0)
        {
            animator.SetBool("isCrouch", true);
            boxCollider.offset = new Vector2(-0.17f, 0.60f);
            boxCollider.size = new Vector2(0.88f, 1.38f);
        }
        else
        {
            animator.SetBool("isCrouch", false);
            boxCollider.offset = new Vector2(0.024f, 1.01f);
            boxCollider.size = new Vector2(0.62f, 2.07f);
        }
    }

    private void MoveAnimation(float horizontal)
    {
        

        float absHorizontal = Mathf.Abs(horizontal);
        animator.SetFloat("Speed", absHorizontal);
        Vector3 scale = transform.localScale;
        if (horizontal > 0)
        {
            scale.x = absHorizontal;
        }
        else if (horizontal < 0)
        {
            scale.x = -1f * absHorizontal;
        }
        transform.localScale = scale;
    }

    private void JumpAnimation(float jump)
    {
        
        if (jump > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}
