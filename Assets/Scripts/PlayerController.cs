using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    private Animator animator;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    [SerializeField] float speed;
    [SerializeField] int jumpForce;

    private Vector2 originalColliderCenter;
    private Vector2 originalColliderSize;

    private Rigidbody2D rb;
    private BoxCollider2D playerCollider;

    bool flip;
    bool _isCrouching;
    [SerializeField] private bool _isOnGround;
    [SerializeField] private bool _isCelingPresent;
 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        animator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();

        flip = false;
        _isCrouching = false;
        _isOnGround = false;
    }
    #endregion
    private void Start()
    {
        originalColliderCenter = playerCollider.offset; //for 3d this property will be coliderObject.center
        originalColliderSize = playerCollider.size;  
    }

    void FixedUpdate()
    {
        GroundAndCelingCheck();
    }

    void Update()
    {
        MovementFunc();
        Jump();
        Crouch();   
    }

    #region Ground and Celing Check
    void GroundAndCelingCheck()
    {
        float raycastGroundDistance = 0.1f;
        float raycastCelingDistance = 2f;
        //int groundLayerMask = LayerMask.GetMask("Ground");
        int bitMask = 1 <<10;

        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, Vector2.down, raycastGroundDistance, bitMask);

        RaycastHit2D celingHit = Physics2D.Raycast(transform.position, Vector2.up, raycastCelingDistance, bitMask);

        _isOnGround = groundHit.collider != null;
        _isCelingPresent = celingHit.collider != null;
    }
    #endregion

    #region Jump function
    void Jump()
    {
        verticalInput = Input.GetAxis("Vertical");
        if (verticalInput > 0 && _isOnGround && !_isCelingPresent)
        {
            animator.SetTrigger("Jump");

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    #endregion

    #region Crouch Function
    void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            if (!_isCrouching)
            {
                _isCrouching = true;
                animator.SetBool("IsCrouching", true);

                //changing size ad position of player's colider
                playerCollider.offset = new Vector2(playerCollider.offset.x, playerCollider.offset.y / 2f);
                playerCollider.size = new Vector2(playerCollider.size.x, playerCollider.size.y / 2f);
            }
        }
        else if (_isCrouching && _isCelingPresent)
        {
            animator.SetBool("IsCrouching", true);
        }
        else
        {
            _isCrouching = false;
            animator.SetBool("IsCrouching", false);
            // Restore the original collider size and position when standing up
            playerCollider.offset = originalColliderCenter;
            playerCollider.size = originalColliderSize;
        }
    }

    #endregion

    #region Movement Fuction
    void MovementFunc()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            animator.SetBool("IsRunning", true);

            if (horizontalInput < 0)
            {
                flip = true;
            }
            else if (horizontalInput > 0)
            {
                flip = false;
            }

            /* if (Mathf.Approximately(horizontalInput, 0f))
             {
                 flip = false;
             }*/

            GetComponent<SpriteRenderer>().flipX = flip;


            Vector3 movement = transform.position;
            movement.x += speed * horizontalInput * Time.deltaTime;
            transform.position = movement;
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }
    #endregion
}
