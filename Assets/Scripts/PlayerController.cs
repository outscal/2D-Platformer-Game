using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    void Update()
    {
        float speed= Input.GetAxis("Horizontal");
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
    }
}
