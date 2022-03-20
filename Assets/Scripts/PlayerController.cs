using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    public float speed;
    bool crouch;
    public Transform transfrm;
    public LayerMask whatIsGround;
    public ScoreController scoreController;


    public float checkRadius;

    internal void KillPlayer()
    {
       // Destroy(gameObject);
    }

    public Rigidbody2D rb;
    public float jumpForce;

    internal void PickUpKey()
    {
        scoreController.IncreaseScore(10);
    }

    private bool isGrounded;

    private void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        PlayerMovementAnimation(horizontal);
        MoveCharacter(horizontal);

        //Jump
        isGrounded = Physics2D.OverlapCircle(transfrm.position, checkRadius, whatIsGround);
        if (isGrounded == true && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    
      
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