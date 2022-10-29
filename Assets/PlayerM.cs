using System.Collections;
using UnityEngine;

public class PlayerM : MonoBehaviour
{

    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;

    private bool isJumping;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    public Vector3 coll;
    public Vector3 coll2;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private BoxCollider2D col;
    [SerializeField] private Animator anim;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
        
    }

    private void Update()
    {
        crouch();
        horizontal = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Speed",Mathf.Abs(horizontal));

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            jumpBufferCounter = 0f;

            StartCoroutine(JumpCooldown());
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }

        Flip();
        if(IsGrounded())
        {
            anim.SetBool("IsJumping", false);
        }
        if(!IsGrounded())
        {
            anim.SetBool("IsJumping", true);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
    }
    void crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetBool("iscrouching", true);
            anim.SetBool("IsJumping", false);
            if(col != null)
            {
                col.size = coll;
                col.offset = coll2;
            }
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            
            anim.SetBool("IsJumping", false);
            if (col != null)
            {
                col.size = new Vector2(0.4f, 2f);
                col.offset = new Vector2(0f, 1f);
            }
        }
    }
}