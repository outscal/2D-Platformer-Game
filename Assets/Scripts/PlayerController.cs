using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;

    private Vector2 originalColliderCenter;
    private Vector2 originalColliderSize;

    private BoxCollider2D playerCollider;

    bool flip;
    bool _isCrouching;
    bool _isJumping;

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

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        animator.SetBool("IsRunning", false);


        if (horizontalInput != 0)
        {
            animator.SetBool("IsRunning", true);
        }
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


        if (verticalInput > 0)
        {
            jump();
        }
        else
        {
            _isJumping= false;
        }


        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            crouch();
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


    void jump()
    {
        if (!_isJumping)
        {
            _isJumping = true;
            animator.SetTrigger("Jump");
        }
    }

    void crouch()
    {
        if (!_isCrouching) {
            _isCrouching = true;
            animator.SetBool("IsCrouching", true);

            //changing size ad position of player's colider
            playerCollider.offset = new Vector2(playerCollider.offset.x, playerCollider.offset.y/2f);
            playerCollider.size = new Vector2(playerCollider.size.x, playerCollider.size.y / 2f);
        }
    }
}
