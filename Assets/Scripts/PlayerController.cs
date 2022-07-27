using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rd2d;
    private GameObject levelStart;
    public float speed;
    public float jump;
    public float lowerDeadPoint;
    private bool midJump= false;
    private bool falling= false;
    private ScoreController scoreController;

    void Start()
    {
        rd2d= transform.GetComponent<Rigidbody2D>();
        animator= transform.GetComponent<Animator>();
        scoreController= GameObject.FindWithTag("Score").GetComponent<ScoreController>();
        levelStart= GameObject.Find("LevelStart");
    }
    void Update()
    {
        float horizontal= Input.GetAxisRaw("Horizontal");
        float vertical= Input.GetAxisRaw("Vertical");
        MovementAnimation(horizontal, vertical);
        Movement(horizontal, vertical);
        CheckForFallDeath();
        
    }
    public void GetPoints()
    {
        scoreController.IncrementScore();
    }
    private void CheckForFallDeath()
    {
        if(transform.position.y<lowerDeadPoint)
        {
            transform.position= levelStart.transform.position;
        }
    }
    private void Movement(float horizontal, float vertical)
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
    private void MovementAnimation(float horizontal, float vertical)
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        midJump= false;
        falling= false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(midJump!= true)
        {
            falling= true;
        }
    }
}
