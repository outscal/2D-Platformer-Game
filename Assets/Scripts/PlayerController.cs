using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D collider2d;
    //public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        float horizontal = Input.GetAxisRaw("Horizontal");
        
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = (-1) * Mathf.Abs(scale.x);
        }
        else if(horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
        CheckForCrouch();
        CheckForJump();

    }

    private void CheckForJump()
    {
        float vertical = Input.GetAxisRaw("Vertical");
       //if(Input.GetKeyDown(KeyCode.Space))
        if(vertical > 0)
        {
            animator.SetTrigger("JumpTrigger");
            //animator.SetBool("Jump", true);
        }
        /*else
        {
            //animator.SetBool("Jump", false);
        }*/
    }

    private void CheckForCrouch()
    {
     
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
            collider2d.size = new Vector2(0.6311399f, 1.327474f);
            collider2d.offset = new Vector2(0.01034069f, 0.5875177f);
        }
        else
        {
            animator.SetBool("Crouch", false);
            collider2d.size = new Vector2(0.6311399f,2.108599f);
            collider2d.offset = new Vector2(0.01034069f, 0.9780799f);
        }

    }
}
