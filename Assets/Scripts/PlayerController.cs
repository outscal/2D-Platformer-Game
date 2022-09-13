using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;
    bool canJump;
    bool IsGrounded;
    bool canDoubleJump;

    [Header("References")]
    [SerializeField]private Animator animator;
    [SerializeField]private BoxCollider2D boxCollider;

    [Header("Hitbox")]
    public Vector2 standingColliderOffset;
    public Vector2 standingColliderSize;
    public Vector2 crouchColliderOffset;
    public Vector2 crouchColliderSize;

    [Header("Movement")]
    public float speed;
    public float jumpForce;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float moveValue = Input.GetAxisRaw("Horizontal");

        if(IsGrounded) canDoubleJump = true;

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            canJump = true;
        }
        else if(Input.GetButtonDown("Jump") && canDoubleJump)
        {
            canJump = true;
            canDoubleJump = false;
        }


        PlayMovementAnimation(moveValue);
        MovePlayer(moveValue);
    }

    private void FixedUpdate()
    {
        if (canJump)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            canJump = false;
        }
    }

    private void MovePlayer(float xAxis)
    {
        transform.position += Vector3.right * xAxis * speed * Time.deltaTime;
    }

    private void PlayMovementAnimation(float xAxis)
    {
        animator.SetFloat("Speed", Mathf.Abs(xAxis));

        Vector3 scale = transform.localScale;

        if (xAxis < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (xAxis > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;


        animator.SetBool("Jump", canJump);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
            CrouchHitBox(true);
        }
        else
        {
            animator.SetBool("Crouch", false);
            CrouchHitBox(false);
        }
    }

    private void CrouchHitBox(bool crouch)
    {
        if(crouch)
        {
            boxCollider.offset = crouchColliderOffset;
            boxCollider.size = crouchColliderSize;
        }
        else
        {
            boxCollider.offset = standingColliderOffset;
            boxCollider.size = standingColliderSize;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            IsGrounded= true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = false;
        }
    }
}
