using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public LayerMask groundLayer;
    public bool onGround = false;
    public float distance;
    void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = 0;
        if (Input.GetKeyDown(KeyCode.Space))
            vertical = Input.GetAxisRaw("Jump");

        Debug.Log(vertical);

        onGround = Physics2D.Raycast(transform.position, new Vector2(0, -1), distance, groundLayer);

        PlayerMovement(horizontal, vertical);
        PlayerAnimation(horizontal, vertical);
        PlayerCrouch();
    }
    private void PlayerMovement(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        if (vertical > 0 && onGround)
            Jump();
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, 1) * jumpForce, ForceMode2D.Impulse);
    }
    private void PlayerCrouch()
    {
        Vector2 offset = boxCollider2D.offset;
        Vector2 size = boxCollider2D.size;
        if (Input.GetKey(KeyCode.LeftControl))
        {
            offset.x = -0.1136989f;
            offset.y = 0.5907992f;
            size.x = 0.8533424f;
            size.y = 1.240493f;
        }
        else
        {
            offset.x = 0.02338372f;
            offset.y = 0.9791999f;
            size.x = 0.5791771f;
            size.y = 2.017294f;
        }
        boxCollider2D.offset = offset;
        boxCollider2D.size = size;
    }
    private void PlayerAnimation(float horizontal, float vertical)
    {
        if (onGround)
            animator.ResetTrigger("jump");

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
            scale.x = -1 * Mathf.Abs(scale.x);
        else if (horizontal > 0)
            scale.x = Mathf.Abs(scale.x);
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        transform.localScale = scale;

        if (vertical > 0)
            animator.SetTrigger("jump");
        animator.SetBool("crouch", Input.GetKey(KeyCode.LeftControl));
    }
}
