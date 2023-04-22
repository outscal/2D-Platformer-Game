using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider2D;

    // [SerializeField] Vector2 boxColliderOffset;
    // [SerializeField] Vector2 boxColliderSize;
    [SerializeField] float jumpDuration = 0.5f;

    private Vector2 initialSize, initialOffset;

    void JumpController()
    {
        animator.SetBool("Jump", false);

    }

    private void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
        initialOffset = gameObject.GetComponent<BoxCollider2D>().offset;
        initialSize = gameObject.GetComponent<BoxCollider2D>().size;
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        MovePlayer(horizontal);
        PlayerMovementAnimation(horizontal);
        
        bool isCrouch = Input.GetKey(KeyCode.LeftControl);
        PlayerCrouchAnimation(isCrouch);

        bool isJump = Input.GetKeyDown(KeyCode.Space);
        PlayerJumpAnimation(isJump);
    }

    private void MovePlayer(float horizontal) 
    {   
        Vector3 position = transform.position;
        position.x += horizontal * moveSpeed * Time.deltaTime;
        transform.position = position; 
    }

    private void PlayerMovementAnimation(float horizontal) 
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
    }

    private void PlayerCrouchAnimation(bool isCrouch) 
    {
        // Player Crouch Animation trigger
        if (isCrouch)
        {
            // If Left Control is Pressed, then player will crouch
            // Also need to resize the box collider...
            animator.SetBool("Crouch", isCrouch);
            //gameObject.GetComponent<BoxCollider2D>().offset = boxColliderOffset;
            //gameObject.GetComponent<BoxCollider2D>().size = boxColliderSize;
        } 
        else
        {
            animator.SetBool("Crouch", isCrouch);
            //gameObject.GetComponent<BoxCollider2D>().offset = initialOffset;
            //gameObject.GetComponent<BoxCollider2D>().size = initialSize;
        }
    }

    private void PlayerJumpAnimation(bool isJump) 
    {
        // Player Jump
        if (isJump)
        {
            animator.SetBool("Jump", true);
            Invoke(nameof(JumpController), jumpDuration);
        }
    }
}
