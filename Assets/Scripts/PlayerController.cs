using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Vector2 newCrouchColliderOffset;
    [SerializeField] private Vector2 newCrouchColliderSize;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;


    private Rigidbody2D rb;
    private enum PlayerState
    {
        idle, 
        walking,
        running,
        crouching,
        jumping
    };

    private Vector2 originalColliderOffset;
    private Vector2 originalColliderSize;
    private PlayerState state;
    private CapsuleCollider2D playerCollider;
    private float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        horizontalInput = 0f;
        state = PlayerState.idle;
        playerCollider = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        originalColliderOffset = playerCollider.offset;
        originalColliderSize = playerCollider.size;
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        CheckDirection();
    }

    void GetPlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        MovePlayer(horizontalInput);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            state = PlayerState.crouching;
            ResizeCollider();
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            state = PlayerState.idle;
            RestoreColliderSize();
        }

        //if (Input.GetAxisRaw("Vertical") > 0f)
        //    PlayerJump();

        animator.SetInteger("PlayerState", (int)state);
    }

    void MovePlayer(float input)
    {
        Vector3 position = transform.position;

        position.x += input * moveSpeed * Time.deltaTime;
        transform.position = position;
    }
    void RestoreColliderSize()
    {
        playerCollider.offset = originalColliderOffset;
        playerCollider.size = originalColliderSize;
    }

    void ResizeCollider()
    {
        playerCollider.offset = newCrouchColliderOffset;
        playerCollider.size = newCrouchColliderSize;
    }
    void CheckDirection()
    {
        if (horizontalInput < 0f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            state = PlayerState.walking;
        }
        else if (horizontalInput > 0.1f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            state = PlayerState.walking;
        }
    }

    void CheckForFalling()
    {
        if (IsGrounded())
        {
            state = PlayerState.idle;
            animator.ResetTrigger("PlayerJumped");
        }
    }

    void PlayerJump()
    {
        animator.SetTrigger("PlayerJumped");
        rb.velocity = new Vector2(rb.velocity.x, jumpPower * Time.deltaTime);  
    }
    bool IsGrounded()
    {
        if (Physics2D.Raycast(playerCollider.bounds.center, -transform.up, 1.3f, LayerMask.GetMask("Platform")))
            return true;

        return false;
    }
}
