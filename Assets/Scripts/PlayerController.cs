using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    void Update()
    {
        float speed= Input.GetAxisRaw("Horizontal");
        float jump= Input.GetAxisRaw("Vertical");
        Debug.Log(speed);
        animator.SetFloat("Speed",Math.Abs(speed));
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
        if(jump>0)
        {
            animator.SetFloat("Jump",jump);
        }
        else
        {
            animator.SetFloat("Jump",0);
        }
    }
}
