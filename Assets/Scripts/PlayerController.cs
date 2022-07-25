using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;
    public Rigidbody2D rd2d;
    private bool midJump= false;
    private bool falling= false;
    void Start()
    {
        rd2d= transform.GetComponent<Rigidbody2D>();
        animator= transform.GetComponent<Animator>();
    }
    void Update()
    {
        float horizontal= Input.GetAxisRaw("Horizontal");
        float vertical= Input.GetAxisRaw("Vertical");
        MovementAnimation(horizontal, vertical);
        Movement(horizontal, vertical);
    }
    void Movement(float horizontal, float vertical)
    {
        if(!animator.GetBool("Crouch"))
        {
            transform.position= transform.position + new Vector3(horizontal* speed * Time.deltaTime, 0, 0);
        }

        if(!midJump && vertical>0.5)
        {
            rd2d.AddForce(new Vector2(0, jump), ForceMode2D.Force);
            midJump= true;
        }
    }
    void MovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed",Math.Abs(horizontal));
        Vector3 scale=transform.localScale;
        if(Input.GetAxis("Horizontal")<0)
        {
            scale.x= -Math.Abs(transform.localScale.x);
        }
        if(Input.GetAxis("Horizontal")>0)
        {
            scale.x= Math.Abs(transform.localScale.x);
        }
        transform.localScale=scale;
        if (Input.GetKey("left ctrl")||Input.GetKey("right ctrl"))
        {
            animator.SetBool("Crouch",true);
        }
        else
        {
            animator.SetBool("Crouch",false);
        }
        if(midJump)
        {
            animator.SetBool("Jump",true);
        }
        else
        {
            animator.SetBool("Jump",false);
        }
        if(falling&&!(Input.GetKey("left ctrl")||Input.GetKey("right ctrl")))
        {
            animator.SetBool("Fall",true);
        }
        else
        {
            animator.SetBool("Fall",false);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        midJump= false;
        falling= false;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(midJump!= true)
        {
            falling= true;
        }
    }
}
