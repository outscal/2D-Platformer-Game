using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public new BoxCollider2D collider;
    private Rigidbody2D rb;
    public Vector2 originalColliderOffset;
    public Vector2 originalColliderSize;
    public bool isCrouched;
    public float speed;
    public float jumpAmount;
    private bool isGrounded = true;


    private void Awake()
    {
        Debug.Log("Player Controller: awake");
        originalColliderOffset = collider.offset;
        originalColliderSize = collider.size;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // input mapping
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool keyDownCtrl = Input.GetKey(KeyCode.LeftControl);
        bool keyUpCtrl = Input.GetKeyUp(KeyCode.LeftControl);

        PlayCrouchAnimation(keyDownCtrl, keyUpCtrl);

        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal, vertical);

    }
    private void PlayCrouchAnimation(bool isKeyDownCrouch, bool isKeyUpCrouch)
    {
        if (isKeyDownCrouch && isCrouched)
        {
            animator.SetBool("isCrouchStillPressed", true);
            collider.offset = new Vector2(0f, 0.53f);
            collider.size = new Vector2(0.6f, 1.05f);
        }

        if (isKeyDownCrouch && !isCrouched)
        {
            isCrouched = true;
            animator.SetBool("isCrouchPressed", true);
            collider.offset = new Vector2(0f, 0.53f);
            collider.size = new Vector2(0.6f, 1.05f);
        }

        if (isKeyUpCrouch && isCrouched)
        {
            isCrouched = false;
            animator.SetBool("isCrouchStillPressed", false);
            collider.offset = originalColliderOffset;
            collider.size = originalColliderSize;
        }

        if (isKeyUpCrouch && !isCrouched)
        {
            animator.SetBool("isCrouchPressed", false);
            collider.offset = originalColliderOffset;
            collider.size = originalColliderSize;
        }
    }

    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        Debug.Log("Velocity Y: " + rb.velocity.y);
        //move animation horizontal
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //move animation vertical or jump
        if (rb.velocity.y == 0)
        {
            animator.SetBool("isJumpPressed", false);
            animator.SetBool("isFalling", false);
        }
        if (rb.velocity.y > 0)
        {
            animator.SetBool("isJumpPressed", true);
        }
        if (rb.velocity.y < 0f)
        {
            animator.SetBool("isJumpPressed", false);
            animator.SetBool("isFalling", true);
        }

    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        //move character horizontally
        Vector2 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //move character vertically 
        if (vertical > 0 && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}