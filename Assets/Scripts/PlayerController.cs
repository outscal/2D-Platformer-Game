using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerController : MonoBehaviour
{
    private bool can_jump = false;
    private bool can_crouch = false;
    public Animator animator;

    private void Update()
    {
        //running left or right
        HoriontalMovement();
        //jumping or crouching
        VerticalMovement();
    }

    private void VerticalMovement()
    {
        float vertical = Input.GetAxis("Vertical");
        if(vertical > 0)
        {
            animator.SetTrigger("Jump");
        }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        else
        {
            animator.SetBool("Crouch", false);
        }
        
    }

    private void HoriontalMovement()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("HorizontalSpeed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = Mathf.Abs(scale.x) * -1;
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
}