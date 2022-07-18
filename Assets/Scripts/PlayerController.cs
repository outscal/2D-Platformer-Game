using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D playerRigidBody;
    public ScoreController scoreController;
    private bool isCrouched = false;
    public float playerSpeed;
    public float jumpAmount;
    private bool isGrounded = true;
    private float horizontal, vertical;
    private float normalSpeed;
    public float crouchedSpeed;
    public int playerHealth = 3;
    [SerializeField] private Image[] healthImageArray;

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
        isCrouched = Input.GetKey(KeyCode.LeftControl);

        // add something meaningful like player movement and animation loop
        PlayCrouchAnimation(isCrouched);
        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal);
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

    private void PlayMovementAnimation(float horizontal)
    {
        //move animation Horizontally
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontal));

        SwitchHorizontalDirection(horizontal);

        //move animation Vertically
        VerticalJumpAnimation();
    }

    private void SwitchHorizontalDirection(float directionX)
    {
        Vector3 scale = transform.localScale;

        if (directionX < 0)
        {
            //changes direction player is facing on x-axis
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (directionX > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    private void VerticalJumpAnimation()
    {
        if (vertical > 0 && isGrounded)
            playerAnimator.SetBool("isJumpPressed", true);

        if (playerRigidBody.velocity.y < 0 && !isGrounded)
        {
            playerAnimator.SetBool("isJumpPressed", false);
            playerAnimator.SetBool("isFalling", true);
        }
        if (playerRigidBody.velocity.y == 0 || isGrounded)
        {
            playerAnimator.SetBool("isJumpPressed", false);
            playerAnimator.SetBool("isFalling", false);
        }
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        SpeedModifier();

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

    private void SpeedModifier()
    {
        _ = isCrouched ? playerSpeed = crouchedSpeed : playerSpeed = normalSpeed;
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
        playerAnimator.SetBool("isPlayerDead", true);
        //get animation time and invoke ReloadLevel after that time * 2
        Invoke("ReloadLevel", playerAnimator.GetCurrentAnimatorStateInfo(0).length * 2);
    }

    public void DamagePlayer()
    {
        //play hurt animation 
        // if health = 0, hurt animation will play and then death animation?
        //playerAnimator.SetBool("Change value to play hurt animation", true);

        playerHealth--;
        UpdateHealthUI();

        if (playerHealth <= 0)
            KillPlayer();
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Executes public member function of scoreController 
    public void PickUpKey()
    {
        scoreController.IncrementScore(10);
    }
    private void UpdateHealthUI()
    {
        for (int i = 0; i < healthImageArray.Length; i++)
        {
            if (i < playerHealth)
                healthImageArray[i].color = Color.red;
            else
                healthImageArray[i].color = Color.clear;
        }
    }
}