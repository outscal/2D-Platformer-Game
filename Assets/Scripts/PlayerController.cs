using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    LayerMask platformLayerMask;

    public Animator animator;
    BoxCollider2D boxcollider2d;
    Rigidbody2D rigidbody2d;
    public float speed;
    public float jump;
    Vector2 size;
    Vector2 offset;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        boxcollider2d = GetComponent<BoxCollider2D>();
        
        size = boxcollider2d.size;
        offset = boxcollider2d.offset;
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
        PlayerVerticalMovement(speedY);
    }

    private void PlayerVerticalMovement(float speedY)
    {
        if(speedY > 0 && IsGrounded())
        {
            rigidbody2d.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxcollider2d.bounds.center, boxcollider2d.bounds.size, 0f, Vector2.down, 0.06f, platformLayerMask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
       
    }

    private void PlayerHorizontalMovement(float speedX)
    {
        Vector3 position = transform.position;
        position.x = transform.position.x + speedX * Time.deltaTime;
        transform.position = position;
    }

    private void PlayerMovementAnimation(float speedX, float speedY)
    {
        RunAnimation(speedX);
        JumpAnimation(speedY);
        CrouchAnimation();
    }

    private void RunAnimation(float speedX)
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

    private void JumpAnimation(float speedY)
    {
        if(speedY > 0 && IsGrounded())
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void CrouchAnimation()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
            boxcollider2d.size = new Vector2(size.x, size.y / 2);
            boxcollider2d.offset = new Vector2(offset.x, offset.y - offset.y / 2);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            boxcollider2d.size = size;
            boxcollider2d.offset = offset;
            animator.SetBool("Crouch", false);
        }
    }
}
