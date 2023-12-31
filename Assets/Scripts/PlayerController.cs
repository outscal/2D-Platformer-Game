using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;


    bool flip;
    bool _isCrouching;
    bool _isJumping;

    private void Start()
    {
        animator = GetComponent<Animator>();
        flip = false;
        _isCrouching = false;
        _isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        animator.SetBool("IsRunning", false);


        if (horizontalInput != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        if (horizontalInput < 0)
        {
            flip = true;
        }
        else if (horizontalInput > 0)
        {
            flip = false;
        }

       /* if (Mathf.Approximately(horizontalInput, 0f))
        {
            flip = false;
        }*/

        GetComponent<SpriteRenderer>().flipX = flip;


        if (verticalInput > 0)
        {
            jump();
        }
        else
        {
            _isJumping= false;
        }


        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            crouch();
        }
        else 
        {
            _isCrouching = false;
            animator.SetBool("IsCrouching", false);
        }
    }


    void jump()
    {
        if (!_isJumping)
        {
            _isJumping = true;
            animator.SetTrigger("Jump");
        }
    }

    void crouch()
    {
        if (!_isCrouching) {
            _isCrouching = true;
            animator.SetBool("IsCrouching", true);
        }
    }
}
