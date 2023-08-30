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

    private Vector2 originalColliderOffset;
    private Vector2 originalColliderSize;
    private CapsuleCollider2D playerCollider;
    private float horizontalInput;

    private enum PlayerState
    {
        idle,
        jumping
    };

    private PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        horizontalInput = 0f;
        playerCollider = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        originalColliderOffset = playerCollider.offset;
        originalColliderSize = playerCollider.size;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForFalling();
        GetPlayerInput();
        CheckDirection();
    }

    void GetPlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        MovePlayer(horizontalInput);
        PlayMoveAnimation();

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("PlayerCrouching", true);
            ResizeCollider();
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("PlayerCrouching", false);
            RestoreColliderSize();
        }
    }

    void PlayMoveAnimation() => animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

    void PlayJumpAnimation() => animator.SetBool("PlayerJumped", true);
  

    void MovePlayer(float inputHorizontal)
    {
        Vector3 position = transform.position;

        position.x += inputHorizontal * moveSpeed * Time.deltaTime;
        transform.position = position;

        if(Input.GetKeyDown(KeyCode.Space) && playerState != PlayerState.jumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            playerState = PlayerState.jumping;
            PlayJumpAnimation();
        }
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
            transform.eulerAngles = new Vector3(0, 180, 0);

        else if (horizontalInput > 0.1f)
            transform.eulerAngles = new Vector3(0, 0, 0);
    }

    void CheckForFalling()
    {
        if (IsGrounded())
        {
            animator.SetBool("PlayerJumped", false);
            playerState = PlayerState.idle;
        }
    }
    bool IsGrounded()
    {
        if (Physics2D.Raycast(playerCollider.bounds.center, -transform.up, 2.3f, LayerMask.GetMask("Platform")))
            return true;

        return false;
    }

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    RaycastHit2D rayhit = Physics2D.Raycast(playerCollider.bounds.center, -transform.up, 2.3f, LayerMask.GetMask("Platform"));
    //    Gizmos.DrawRay(playerCollider.bounds.center, -transform.up);

    //    if (rayhit)
    //    {
    //        Gizmos.color = Color.red;
    //        Gizmos.DrawRay(playerCollider.bounds.center, -transform.up);
    //    }
    //}
}
