using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //State variables
    public Animator animator;
    public float speed;
    //Cached references
    BoxCollider2D boxCollider;
    Rigidbody2D rigidBody2D;
    
    bool isGrounded;
    bool isCrouch;
    private void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        rigidBody2D = GetComponent<Rigidbody2D>();

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        Debug.Log("Collision : " + collision.gameObject.name + " is grounded =  " + isGrounded);
        if (isGrounded)
        {
            rigidBody2D.gravityScale = 0;
        }
    }

    private void Update()
    {
        float hSpeed = Input.GetAxisRaw("Horizontal");
        float vSpeed = Input.GetAxisRaw("Vertical");
        PlayerMovementHorizontal(hSpeed);
        ColliderWhenIdle();
        PlayerJump(vSpeed);
        PlayerCrouch();
        MoveCharacter(hSpeed);


    }

    private void MoveCharacter(float hSpeed)
    {
        if (!isCrouch)
        {
            Vector3 playerPos = transform.position;
            playerPos.x += (hSpeed * speed * Time.deltaTime);
            transform.position = playerPos;
        }
    }

    private void ColliderWhenIdle()
    {
        boxCollider.offset = new Vector2(0.024f, 1.01f);
        boxCollider.size = new Vector2(0.62f, 2.07f);
    }

    private void PlayerJump(float vSpeed)
    {
        if (vSpeed == 1)
        {
            animator.SetBool("Jump", true);
            boxCollider.offset = new Vector2(0.15f, 1.75f);
            boxCollider.size = new Vector2(0.86f, 1.45f);
        }
        else if (vSpeed < 1)
        {
            animator.SetBool("Jump", false);

        }
    }

    private void PlayerCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", true);
            isCrouch = true;
            boxCollider.offset = new Vector2(-0.17f, 0.60f);
            boxCollider.size = new Vector2(0.88f, 1.38f);
        }
        else if (!Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", false);
            isCrouch = false;
        }
    }

    private void PlayerMovementHorizontal(float hSpeed)
    {
        animator.SetFloat("Speed", Mathf.Abs(hSpeed));
        Vector3 scale = transform.localScale;
        if (hSpeed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (hSpeed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
        
    }
}
