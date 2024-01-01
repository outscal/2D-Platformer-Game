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
    //[SerializeField] GameObject ground;

    private Vector2 originalColliderCenter;
    private Vector2 originalColliderSize;

    private BoxCollider2D playerCollider;

    bool flip;
    bool _isCrouching;
    [SerializeField] private bool _isOnGround;

    #endregion
    private void Start()
    {
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();

        originalColliderCenter = playerCollider.offset; //for 3d this property will be coliderObject.center
        originalColliderSize = playerCollider.size;

        flip = false;
        _isCrouching = false;
        _isOnGround = false;
    }

    void FixedUpdate()
    {
        groundCheck();
    }

    void Update()
    {
        movementFunc();
        jump();
        crouch();   
    }

    #region GroundCheck
    /*void groundCheck()
    {
        if (transform.position.y - ground.transform.position.y < 2)
        {
            _isOnGround = true;
        }
        else
        {
            _isOnGround = false;
        }
        Debug.Log(transform.position.y - ground.transform.position.y);
    }*/
    void groundCheck()
    {
        float raycastDistance = 0.1f;

        //LayerMask groundLayerMask = LayerMask.GetMask("Ground");
        int bitMAsk = 1 <<10;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, bitMAsk);


      /*  if (hit.collider != null)
        {
            Debug.Log("Hit the ground: " + hit.collider.name);
        }
        else
        {
            Debug.Log("Not on the ground");
        }*/

        _isOnGround = hit.collider != null;
    }
    #endregion

    #region Jump function
    void jump()
    {
        if (verticalInput > 0 && _isOnGround)
        {
            animator.SetTrigger("Jump");

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, 5);
        }
    }
    #endregion

    #region Crouch Function
    void crouch()
    {
        verticalInput = Input.GetAxis("Vertical");
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
    void movementFunc()
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
