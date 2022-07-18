using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D playerRigidBody;
    public ScoreController scoreController;
    public HealthController healthController;
    private bool isCrouched;
    public float playerSpeed;
    public float jumpAmount;
    private bool isGrounded = true;
    private float horizontal, vertical;
    private bool crouchPressed;
    private float normalSpeed;
    public float crouchedSpeed;

    private void Awake()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        normalSpeed = playerSpeed;
    }

    private void Update()
    {
        // input mapping
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        crouchPressed = Input.GetKey(KeyCode.LeftControl);

        PlayCrouchAnimation(crouchPressed);

        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal, vertical);

    }

    private void PlayCrouchAnimation(bool isKeyDownCrouch)
    {
        if (isKeyDownCrouch)
        {
            isCrouched = true;
            playerAnimator.SetBool("isCrouchPressed", true);
        }
        else
        {
            isCrouched = false;
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
        if (isCrouched)
        {
            playerSpeed = crouchedSpeed;
        }
        else
        {
            playerSpeed = normalSpeed;
        }

        //move character horizontally
        Vector3 position = transform.position;
        position.x += horizontal * playerSpeed * Time.deltaTime;
        transform.position = position;

        //move character vertically 
        if (vertical > 0 && isGrounded && !isCrouched)
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
    public void KillPlayer()
    {
        Debug.Log("Game Over.\n You have died.");
        // playerAnimator.Play("Base Layer.Player_Death", -1, 0.2f);
        playerAnimator.SetBool("isPlayerDead", true);
        //get animation time
        float waitTime = playerAnimator.GetCurrentAnimatorStateInfo(0).length;
        Invoke("ReloadLevel", waitTime);
    }

    public void DamagePlayer()
    {
        //play hurt animation
        //playerAnimator.SetBool("Change value to play hurt animation", true);

        if(healthController.playerHealth <= 0)
        {
            KillPlayer();
        } else
        {
            healthController.playerHealth--;
            healthController.UpdateHealth();
        }
    }

    private void ReloadLevel()
    {
        Debug.Log("Restarting!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Executes public member function of scoreController 
    public void PickUpKey()
    {
        scoreController.IncrementScore(10);
    }
}