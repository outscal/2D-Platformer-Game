using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float JumpForce;

    private Animator animator;
    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
      animator = GetComponent<Animator>();  
    }
      void Update()
    {
       float speed = Input.GetAxisRaw("Horizontal");
       animator.SetFloat("Speed", Mathf.Abs(speed));

       Vector3 scale = transform.localScale;
       if(speed<0)
       {
           scale.x = -1f * Mathf.Abs(scale.x);
       }
       else if (speed>0)
       {
           scale.x = Mathf.Abs(scale.x);
       }
       transform.localScale =scale;

       if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0,JumpForce),ForceMode2D.Impulse);
            setJump();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
           setCrouch();
        }
    }

    void setJump () 
    {
        animator.SetTrigger("Jump");
    }

    void setCrouch ()
    {
        animator.SetTrigger("Crouch");
    }// update
}
