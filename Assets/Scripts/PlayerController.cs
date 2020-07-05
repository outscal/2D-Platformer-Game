using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;

   

    private void Awake()
    {
        Debug.Log("player controller Awake");
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        PlayerMovementAnimation(horizontal);
        PlayerMovement(horizontal);
        PlayerCrouch();
        PlayerJump(vertical);
    }



    private void PlayerJump(float vertical)
    {
        if (vertical > 0)
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }
    }

    private void PlayerCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", false);
        }
    }

    private void PlayerMovement(float horizontal)
    {
            Vector3 position = transform.position;
            position.x += horizontal * speed * Time.deltaTime;
            transform.position = position;
    }

    private void PlayerMovementAnimation(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
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
    }
}
