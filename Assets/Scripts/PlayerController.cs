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
   // [SerializeField] float crouchSpeed;

    private Rigidbody2D rb;
    private BoxCollider2D playerBoxCollider;

    private Vector2 originalColliderCenter;
    private Vector2 originalColliderSize;

    bool flip;
    bool _isCrouching;
    [SerializeField] private bool _isOnGround;
    [SerializeField] private bool _isCelingPresent;
 

    private void Awake()
    {

        flip = false;
        _isCrouching = false;
        _isOnGround = false;
    }
    #endregion
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        animator = GetComponent<Animator>();
        playerBoxCollider = GetComponent<BoxCollider2D>();

        originalColliderCenter = playerBoxCollider.offset; //for 3d this property will be coliderObject.center
        originalColliderSize = playerBoxCollider.size;

    }

    void FixedUpdate()
    {
        GroundAndCelingCheck();
        Jump();
    }

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");

        MovementFunc();
      
        Crouch();   
    }

    #region Ground and Celing Check
    void GroundAndCelingCheck()
    {
        float raycastGroundDistance = 0.2f;
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
        
        if (verticalInput > 0 && _isOnGround)
        {
            animator.SetTrigger("Jump");

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        /*else if(_isOnGround)
        {
            animator.SetBool("Jump", false);
        }*/
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
                animator.SetBool("Crouch", true);

                //changing size ad position of player's colider
                playerBoxCollider.offset = new Vector2(playerBoxCollider.offset.x, playerBoxCollider.offset.y / 2f);
                playerBoxCollider.size = new Vector2(playerBoxCollider.size.x, playerBoxCollider.size.y / 2f);
            }
        }
        else if (_isCrouching && _isCelingPresent)
        {
            animator.SetBool("Crouch", true);
        }
        else
        {
            _isCrouching = false;
            animator.SetBool("Crouch", false);
            // Restore the original collider size and position when standing up
            playerBoxCollider.offset = originalColliderCenter;
            playerBoxCollider.size = originalColliderSize;
        }
    }

    #endregion

    #region Movement Fuction
    void MovementFunc()
    {
        animator.SetFloat("Run", Mathf.Abs(horizontalInput));

        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
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
    }
    #endregion
}
