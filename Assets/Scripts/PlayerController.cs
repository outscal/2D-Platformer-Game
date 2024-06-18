using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    // private 
    private float speed;
    private float jumpPower;

    // public
    public Animator animator;
    public BoxCollider2D playerBox;

    // Start is called before the first frame update
    void Start()
    {
       playerBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Facing();
        Jump();
        Crouching();
    }

    void Jump()
    {
        jumpPower = Input.GetAxisRaw("Vertical");

        animator.SetFloat("JumpPower", Mathf.Abs(jumpPower));

        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
        
    }

    void Facing()
    {
        speed = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(speed));

        Vector3 scale = transform.localScale;

        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            animator.SetBool("IsCrouching", false);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            animator.SetBool("IsCrouching", false);
        }
        transform.localScale = scale;
    }

    void Crouching()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("IsCrouching", true);
            playerBox.size = new Vector2(0.8f, 1.4f);
            playerBox.offset = new Vector2(0, 0.6f);
        } else
        {
            playerBox.size = new Vector2(0.6f, 2f);
            playerBox.offset = new Vector2(0f, 1f);
        }
    }
}
