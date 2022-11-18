using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D boxcollider;
    public float speed;
    public float jump;
    Vector2 size;
    Vector2 offset;
    private void Awake()
    {
        size = boxcollider.size;
        offset = boxcollider.offset;
    }


    // Update is called once per frame
    void Update()
    {
        float speedX = Input.GetAxisRaw("Horizontal");
        float speedY = Input.GetAxisRaw("Vertical");
        PlayerMovement(speedX, speedY);
        PlayerMovementAnimation(speedX, speedY);
    }

    private void PlayerMovement(float speedX, float speedY)
    {
        PlayerHorizontalMovement(speedX);
        PlayerJump(speedY);
        PlayerCrouch();
    }

    private void PlayerHorizontalMovement(float speedX)
    {
        Vector3 position = transform.position;
        position.x = transform.position.x + speedX * Time.deltaTime;
        transform.position = position;
    }

    private void PlayerMovementAnimation(float speedX, float speedY)
    {
        animator.SetFloat("Speed", Mathf.Abs(speedX));
        Vector3 scale = transform.localScale;
        if (speedX < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speedX > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }

    private void PlayerJump(float speedY)
    {
        if(speedY > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
        
        
    }

    private void PlayerCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
            boxcollider.size = new Vector2(size.x, size.y / 2);
            boxcollider.offset = new Vector2(offset.x, offset.y - offset.y / 2);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            boxcollider.size = size;
            boxcollider.offset = offset;
            animator.SetBool("Crouch", false);
        }
    }
}
