using UnityEngine;
using UnityEngine.Tilemaps;

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
    public int NumberOfJumps = 1;
    [SerializeField] int jumpCount;
    int jumpCountAnim;
    int count;
    void Awake()
    {
        count = 0;
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        jumpCount = NumberOfJumps;
        jumpCountAnim = NumberOfJumps;
    }
    void Update()
    {
        float horizontal = 0;
        float vertical = 0;

        if (!Input.GetKey(KeyCode.LeftControl))
            horizontal = Input.GetAxisRaw("Horizontal");

        onGround = Physics2D.Raycast(transform.position, new Vector2(0, -1), distance, groundLayer);

        PlayerMovement(horizontal, vertical);
        PlayerAnimation(horizontal, vertical);
        if (onGround)
            PlayerCrouch();
    }
    private void PlayerMovement(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
        if (onGround)
        {
            jumpCount = NumberOfJumps;
        }
        if (Input.GetKeyDown(KeyCode.W) && jumpCount != 0)
        {
            count++;
            Debug.Log("Count : " + count);
            Debug.Log("Jump got pressed " + jumpCount);
            jumpCount = jumpCount - 1;
            Debug.Log("Pressed " + jumpCount);
            Jump();
        }
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
        {
            animator.ResetTrigger("jump");
            jumpCountAnim = NumberOfJumps;
        }
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
            scale.x = -1 * Mathf.Abs(scale.x);
        else if (horizontal > 0)
            scale.x = Mathf.Abs(scale.x);
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        transform.localScale = scale;

        if (Input.GetKeyDown(KeyCode.W) && jumpCountAnim != 0)
        {
            jumpCountAnim = jumpCountAnim - 1;
            animator.SetTrigger("jump");
        }
        if (onGround)
            animator.SetBool("crouch", Input.GetKey(KeyCode.LeftControl));
        else
            animator.SetBool("crouch", false);
    }
    /*
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "platform")
        {
            Debug.Log("Collided with platform!");
            Vector2 playerVector = rb.velocity;
            Vector2 platformVector = collider.gameObject.transform.up;
            Debug.Log(playerVector);
            Debug.Log(platformVector);
            Debug.Log(Vector2.Dot(playerVector, platformVector));
            if (Vector2.Dot(playerVector, platformVector) < 0)
            {
                collider.gameObject.GetComponent<TilemapCollider2D>().isTrigger = false;
            }
            else
            {
                collider.gameObject.GetComponent<TilemapCollider2D>().isTrigger = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "platform")
        {
            Debug.Log("Trigger exit with platform!");
            collider.gameObject.GetComponent<TilemapCollider2D>().isTrigger = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            Debug.Log("Collision exit with platform!");
            collision.gameObject.GetComponent<TilemapCollider2D>().isTrigger = true;
        }
    }
    */
}
