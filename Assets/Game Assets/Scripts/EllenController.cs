using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllenController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    // Declare a variable to store the result of the raycast

    // Define the length of the raycast
    float rayLength = 0.5f;
    BoxCollider2D boxColliderScale;
    // Define the layer mask to filter which colliders to hit
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
         boxColliderScale = gameObject.GetComponent<BoxCollider2D>();

    }

    void Update()
    {
        checkGround();
        // Handle player movement and jumping input
        HandleMovement();
        HandleJumping();
        StealthMovement();
    }


    void checkGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);

        // Check if the ray hit anything
        if (hit.collider != null)
        {
            // The ray hit a collider on the ground layer
            isGrounded = true;
        }
        else
        {
            // The ray did not hit anything
            isGrounded = false;
        }
    }
    void HandleMovement()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(moveInput));

        // Move player horizontally
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip character if moving left/right
        if (moveInput != 0)
        {
            transform.localScale = new Vector3(moveInput, 1, 1);
        }
    }

    void StealthMovement()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                animator.SetBool("IsCrouching", true);
                gameObject.GetComponent<BoxCollider2D>();
               // collider.size = new Vector3(collider.size.x, 100, collider.size.z)
              boxColliderScale.size =new Vector2(boxColliderScale.size.x,boxColliderScale.size.y/2) ;
                boxColliderScale.offset = new Vector2(boxColliderScale.offset.x, boxColliderScale.offset.y / 2);

            }
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                animator.SetBool("IsCrouching", false);
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(boxColliderScale.size.x, boxColliderScale.size.y);
                boxColliderScale.offset = new Vector2(boxColliderScale.offset.x, boxColliderScale.offset.y);

            }
        }
    }
    void HandleJumping()
    {
        animator.SetBool("IsGrounded", isGrounded);

        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }
    }

    void FixedUpdate()
    {
        // Handle jumping animation states
        HandleJumpAnimations();
    }

    void HandleJumpAnimations()
    {
        if (rb.velocity.y > 0.1f)
        {
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsFalling", false);
            isGrounded = false;
        }
        else if (rb.velocity.y < -0.1f)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);

        }
    }
}
