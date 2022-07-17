using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D playerRigidBody;
    public ScoreController scoreController;
    private bool isCrouched;
    public float playerSpeed;
    public float jumpAmount;
    private bool isGrounded = true;
    private float horizontal, vertical;
    private bool keyDownCtrl, keyUpCtrl;


    private void Awake()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    public void PickUpKey()
    {
        scoreController.IncrementScore(10);
    }

    private void Update()
    {
        // input mapping
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        keyDownCtrl = Input.GetKey(KeyCode.LeftControl);
        keyUpCtrl = Input.GetKeyUp(KeyCode.LeftControl);

        PlayCrouchAnimation(keyDownCtrl, keyUpCtrl);

        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal, vertical);

    }
    private void PlayCrouchAnimation(bool isKeyDownCrouch, bool isKeyUpCrouch)
    {
        if (isKeyDownCrouch && isCrouched)
        {
            playerAnimator.SetBool("isCrouchStillPressed", true);
        }

        if (isKeyDownCrouch && !isCrouched)
        {
            isCrouched = true;
            playerAnimator.SetBool("isCrouchPressed", true);
        }

        if (isKeyUpCrouch && isCrouched)
        {
            isCrouched = false;
            playerAnimator.SetBool("isCrouchStillPressed", false);
        }

        if (isKeyUpCrouch && !isCrouched)
        {
            playerAnimator.SetBool("isCrouchPressed", false);
        }
    }

    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        
        //move animation horizontal
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontal));
        
        Vector3 scale = transform.localScale;

        if (horizontal < 0)
        {
            //change direction player is facing on x-axis
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //move animation vertical or jump
        //alone velocity is slightly unpredictive if using with moving colliders
        //can use separate collider which is static only for ground detection
        if (playerRigidBody.velocity.y == 0 || isGrounded)
        {
            playerAnimator.SetBool("isJumpPressed", false);
            playerAnimator.SetBool("isFalling", false);
        }
        if (vertical > 0)
        {
            playerAnimator.SetBool("isJumpPressed", true);
        }
        if (playerRigidBody.velocity.y < 0 && !isGrounded)
        {
            playerAnimator.SetBool("isJumpPressed", false);
            playerAnimator.SetBool("isFalling", true);
        }

    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        //move character horizontally
        Vector3 position = transform.position;
        position.x += horizontal * playerSpeed * Time.deltaTime;
        transform.position = position;

        //move character vertically 
        if (vertical > 0 && isGrounded)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpAmount);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}