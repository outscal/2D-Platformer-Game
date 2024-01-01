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

    private Vector2 originalColliderCenter;
    private Vector2 originalColliderSize;

    private BoxCollider2D playerCollider;

    bool flip;
    bool _isCrouching;
    bool _isJumping;

    #endregion
    private void Start()
    {
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();

        originalColliderCenter = playerCollider.offset; //for 3d this property will be coliderObject.center
        originalColliderSize = playerCollider.size;

        flip = false;
        _isCrouching = false;
        _isJumping = false;
    }

    void Update()
    {
        movementFunc();
        jump();
        crouch();   
    }

    #region Jump function
    void jump()
    {
        if (verticalInput > 0)
        {
            if (!_isJumping)
            {
                _isJumping = true;
                animator.SetTrigger("Jump");
            }
        }
        else
        {
            _isJumping = false;
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
