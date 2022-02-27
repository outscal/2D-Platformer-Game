using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;



public class PlayerController : MonoBehaviour
{

    public Animator animator;
    public float speed;
    bool crouch;
    public Transform transfrm;
    public LayerMask layerMask;

    public float jumpForce = 10f;
    public Rigidbody2D rb;


    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        PlayerMovementAnimation(horizontal);
        MoveCharacter(horizontal);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    private void Jump()
    {
        Vector3 movement = new Vector3(rb.velocity.x, jumpForce, 0);
        rb.velocity = movement; 
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(transfrm.position, 0.5f,layerMask);
        if (groundCheck.gameObject != null)
        {
            return true;
        }
        return false;
    }
    private void MoveCharacter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    void PlayerMovementAnimation(float horizontal)
    {

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

       
        //crouching
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            crouch = true;
            animator.SetBool("Crouch", crouch);
        }
        if (Input.GetKeyUp(KeyCode.CapsLock))
        {
            crouch = false;
            animator.SetBool("Crouch", crouch);
        }


        //positioning
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
        float verticle = Input.GetAxisRaw("Jump");
        if (verticle > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}