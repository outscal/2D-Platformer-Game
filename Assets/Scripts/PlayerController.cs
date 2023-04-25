using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpDuration = 0.5f;
    public float jumpForce;

    [SerializeField] LayerMask platformLayer;

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider2D;
    public Rigidbody2D rb2D;

        private Vector2 initialSize, initialOffset;

    void JumpController()
    {
        animator.SetBool("Jump", false);
    }

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer= GetComponent<SpriteRenderer>();
        boxCollider2D= GetComponent<BoxCollider2D>();
        Debug.Log("Box collider extents: " + boxCollider2D.bounds.extents);
    }

    private void FixedUpdate()
    {
        IsGrounded();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        bool vertical = Input.GetKeyDown(KeyCode.Space);
        bool isCrouch = Input.GetKey(KeyCode.LeftControl);
        
        if(!isCrouch)
        {
            // Now player can't move if he is in Crouch state
            MovePlayer(horizontal);
        }
        PlayerMovementAnimation(horizontal, vertical, isCrouch);
    }

    private void MovePlayer(float horizontal) 
    {   
        Vector3 position = transform.position;
        position.x += horizontal * moveSpeed * Time.deltaTime;
        transform.position = position; 
    }

    private void PlayerMovementAnimation(float horizontal, bool vertical, bool isCrouch) 
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        
        if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        } 
        else if (horizontal > 0)
        { 
            spriteRenderer.flipX= false;
        }

        // Player Jump
        if (vertical && IsGrounded())
        {
            animator.SetBool("Jump", true);
            Invoke(nameof(JumpController), jumpDuration);
            rb2D.AddForce(transform.up * jumpForce);
        }

        // Player Crouch Animation trigger
        if (isCrouch)
        {
            // If Left Control is Pressed, then player will crouch
            animator.SetBool("Crouch", isCrouch);
            Debug.Log("Box collider extents: " + boxCollider2D.bounds.extents);

        }
        else
        {
            animator.SetBool("Crouch", isCrouch);
        }
    }

    private bool IsGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeight, platformLayer);
        Color rayColor;
        if(raycastHit.collider != null)
        {
            rayColor = Color.green;
            animator.SetBool("IsGrounded", true);
        } else
        {
            rayColor = Color.red;
            animator.SetBool("IsGrounded", false);
        }
        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extents.y + extraHeight), rayColor);
        //Debug.Log("Player has hit: " + raycastHit.collider);
        return raycastHit.collider != null;
    }
}
