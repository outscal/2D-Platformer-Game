using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerControler : MonoBehaviour
{
    public bool onGround;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private BoxCollider2D playerBoxCollider;
    private int score = 0;
    

    private Rigidbody2D playerRigidBody;
    private SpriteRenderer playerSpriteRenderer;
    private void Awake()
    {
        playerSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        PrintScore();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        bool jumpInput = Input.GetKey(KeyCode.Space);
        PlayerAnimation(horizontalInput, verticalInput, jumpInput);
        PlayerMovement(horizontalInput, verticalInput, jumpInput);
    }

    public void IncreaseScore(int additionScore)
    {
        score += additionScore;
        PrintScore();
    }

    private void PrintScore()
    {
        scoreText.text = "Score: " + score;
    }

    private void PlayerMovement(float horizontalInput, float verticalInput, bool jumpInput)
    {
        Vector3 playerPosition = transform.position;
        playerPosition.x += (speed * horizontalInput * Time.deltaTime);
        transform.position = playerPosition;
        if (((verticalInput > 0) || (jumpInput) ) && onGround)
        {
            playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void PlayerAnimation(float horizontalInput, float verticalInput, bool jumpInput)
    {
        PlayerHorizontalMovementAnimation(horizontalInput);
        PlayerJumpAnimation(verticalInput, jumpInput);
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

    private void PlayerJumpAnimation(float verticalInput, bool jumpInput)
    {
        if (verticalInput > 0 || jumpInput)
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
