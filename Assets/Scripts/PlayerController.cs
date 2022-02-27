using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{

    public Animator animator;
    public float speed;
    bool crouch;


    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
       // float jump = Input.GetAxisRaw("Verticle");
        PlayerMovementAnimation(horizontal);
        MoveCharacter(horizontal);
    }

    private void MoveCharacter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    void PlayerMovementAnimation(float horizontal)
    {

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        //crouching
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            crouch = true;
            animator.SetBool("Crouch", crouch);
        }
        if (Input.GetKeyUp(KeyCode.CapsLock))
        {
            crouch = false;
            animator.SetBool("Crouch", crouch);
        }


        //positioning
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