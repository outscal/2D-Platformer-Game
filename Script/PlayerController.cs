using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    [Tooltip("Move Speed is set static in crouch after experimentation")]
    public float moveSpeed, jumpForce;
    float horizontalValue,verticalValue;
    Vector2 originalColliderSize,originalOffset;
    Rigidbody2D rgbd;
    BoxCollider2D PlayerCollider;
    public ScoreController scoreController;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
        PlayerCollider = GetComponent<BoxCollider2D>();
        originalColliderSize = PlayerCollider.size;
        originalOffset = PlayerCollider.offset;
    }
    // Update is called once per frame
    void Update()
    {
        GetHorizontalInput();
        GetVerticalInput();
        MoveJumpPlayer(horizontalValue,verticalValue);
        PlayJumpAnimation();
        InputForCrouch();
        SetAnimatorSpeedValue();        
    }

    public void GetHorizontalInput()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");        
    }
    
    public void GetVerticalInput()
    {
        verticalValue = Input.GetAxisRaw("Jump");        
    }

    private void SetAnimatorSpeedValue()
    {
        CheckFlipped();
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontalValue));
    }

    private void CheckFlipped()
    {
        Vector3 scale = transform.localScale;
        if (horizontalValue < 0)
        {
            scale.x = -1 *Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    private void MoveJumpPlayer(float horizontal,float vertical)
    {
        Vector2 pos = transform.position;
        pos.x = pos.x + horizontal * moveSpeed*Time.deltaTime;
        transform.position = pos;
        if (vertical > 0)
        {
            rgbd.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);        
        }
    }

    private void PlayJumpAnimation()
    {
        if (verticalValue>0)
        {
            playerAnimator.SetBool("isJump", true);
        }
        else
        {
            playerAnimator.SetBool("isJump", false);
        }
    }

    private void InputForCrouch()
    {
        if(Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.DownArrow))
        {
            playerAnimator.SetBool("isCrouch", true);
            PlayerCollider.size = new Vector2(PlayerCollider.size.x, 1.2f);
            PlayerCollider.offset = new Vector2(PlayerCollider.offset.x, .6f);
            moveSpeed = 6; // moves slow when crouching
        }
        else
        {
            playerAnimator.SetBool("isCrouch", false);
            PlayerCollider.size = originalColliderSize;
            PlayerCollider.offset = originalOffset;
            moveSpeed = 8;
        }
    }

}
