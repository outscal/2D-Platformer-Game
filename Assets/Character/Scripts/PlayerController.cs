using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float InputMovementDirection;
    private Rigidbody2D rb;
    private Animator anim;

   
    private int facingDirection = 1;

    public float MovementSpeed = 10.0f;
    

    public float groundCheckRadius;
    
    private bool isFacingRight = true;
    private bool isWalking;
    private bool isGrounded;
    

  

    public Transform groundCheck;
    public LayerMask whatIsGround;





    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimation();
        

    }
    private void FixedUpdate()
    {
        ApplyMovement();
        CheckSurronding();
       
    }

    private void CheckMovementDirection()
    {
        if (isFacingRight && InputMovementDirection < 0)
        {
            Flip();
        }
        else if (!isFacingRight && InputMovementDirection > 0)
        {
            Flip();
        }
        if (rb.velocity.x != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }
    private void CheckInput()
    {
        InputMovementDirection = Input.GetAxisRaw("Horizontal");
    }
    private void UpdateAnimation()
    {
        anim.SetFloat("xvelocity", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
        
        
    }
   

    
    private void ApplyMovement()
    {
        rb.velocity = new Vector2(MovementSpeed * InputMovementDirection, rb.velocity.y);
        
    }
    private void CheckSurronding()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        
    }
    private void Flip()
    {
        facingDirection *= -1;
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        
    }
    
    
    

}
