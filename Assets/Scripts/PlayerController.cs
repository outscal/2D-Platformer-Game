using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D playerCollider;
    public float crouchHeight = 0.5f;
    public float offset;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public float moveSpeed = 5f;

    private Vector2 originalColliderSize;
    private Vector2 originalColliderOffset;
    private Rigidbody2D rb;
    public bool isGrounded;

    void Start()
    {
        originalColliderSize = playerCollider.size;
        originalColliderOffset = playerCollider.offset;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
        HandleCrouch();
        HandleJump();
    }

    private void HandleMovement()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));

        if (speed < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (speed > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if (speed != 0)
        {
            transform.Translate(Vector3.right * speed * moveSpeed * Time.deltaTime);
        }
    }

    private void HandleCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouching", true);
            playerCollider.size = new Vector2(originalColliderSize.x, crouchHeight);
            playerCollider.offset = new Vector2(originalColliderOffset.x, offset);
        }
        else
        {
            animator.SetBool("isCrouching", false);
            playerCollider.size = originalColliderSize;
            playerCollider.offset = originalColliderOffset;
        }
    }

    private void HandleJump()
    {
        if (isGrounded && Input.GetAxisRaw("Vertical") > 0)
        {
            animator.SetBool("Jump", true);
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
        else if (isGrounded)
        {
            animator.SetBool("Jump", false);
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
