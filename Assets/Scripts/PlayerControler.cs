using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private BoxCollider2D playerBoxCollider;
    private Rigidbody2D playerRigidBody;
    private SpriteRenderer playerSpriteRenderer;
    private void Awake()
    {
        playerSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Jump");
        PlayerAnimation(horizontalInput, verticalInput);
        PlayerMovement(horizontalInput, verticalInput);
    }

    private void PlayerMovement(float horizontalInput, float verticalInput)
    {
        Vector3 playerPosition = transform.position;
        playerPosition.x += (speed * horizontalInput * Time.deltaTime);
        transform.position = playerPosition;
        if (verticalInput > 0)
        {
            playerRigidBody.AddForce(Vector2.up * jumpForce,ForceMode2D.Force);
        }
    }

    private void PlayerAnimation(float horizontalInput, float verticalInput)
    {
        PlayerHorizontalMovementAnimation(horizontalInput);
        PlayerJumpAnimation(verticalInput);
        PlayerCrouchAnimation();
    }

    private void PlayerCrouchAnimation()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            bool isCourching = playerAnimator.GetBool("Crouch");
            playerAnimator.SetBool("Crouch", !isCourching);
            isCourching = playerAnimator.GetBool("Crouch");
            Vector2 size = playerBoxCollider.size;
            Vector2 offset = playerBoxCollider.offset;
            if (isCourching)
            {
                size.y /= 2f;
                offset.y /= 2f;
            }
            else
            {
                size.y *= 2f;
                offset.y *= 2f;
            }
            playerBoxCollider.size = size;
            playerBoxCollider.offset = offset;
        }
    }

    private void PlayerJumpAnimation(float verticalInput)
    {
        if (verticalInput > 0)
        {
            playerAnimator.SetBool("Jump", true);
        }
        else
        {
            playerAnimator.SetBool("Jump", false);

        }
    }

    private void PlayerHorizontalMovementAnimation(float horizontalInput)
    {
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        if (horizontalInput < 0)
        {
            playerSpriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            playerSpriteRenderer.flipX = false;
        }
    }
}
