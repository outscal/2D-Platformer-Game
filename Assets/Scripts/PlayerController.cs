using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D playerCollider; // Reference to the player's collider
    private Vector2 originalColliderSize; // Store the original size of the collider
    private Vector2 originalCollideroffset; // Store the original offset of the collider
    public float crouchHeight = 0.5f; // Factor to reduce the collider height while crouching
    public float offset;
    public float jumpForce = 5f; // Force applied for jumping

    private Rigidbody2D rb; // Reference to the player's Rigidbody2D component
    private bool isGrounded = true; // Flag to check if the player is grounded

    // Start is called before the first frame update
    void Start()
    {
        originalColliderSize = playerCollider.size; // Store the original size of the collider
        originalCollideroffset = playerCollider.offset; // Store the original offset of the collider
        rb = GetComponent<Rigidbody2D>(); // Initialize the Rigidbody2D component
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        // Crouch logic
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouching", true);
            playerCollider.size = new Vector2(originalColliderSize.x,  crouchHeight);
            playerCollider.offset = new Vector2(originalCollideroffset.x, offset); // Adjust the offset to match the new size
        }
        else
        {
            animator.SetBool("isCrouching", false);
            playerCollider.size = originalColliderSize; // Reset to original size
            playerCollider.offset = originalCollideroffset; // Reset to original offset
        }

        // Jump logic
        if (isGrounded && Input.GetAxisRaw("Vertical") > 0)
        {
            animator.SetBool("Jump", true);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false; // Player is no longer grounded
        }

        // Set the Jump animation to false when the player is grounded
        if (isGrounded)
        {
            animator.SetBool("Jump", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player lands on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
