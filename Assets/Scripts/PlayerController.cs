using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator; // Reference to the Animator
    [SerializeField] private Rigidbody2D _rb; // Reference to the Rigidbody2D
    private AnimatorStateInfo stateInfo;

    private GameManagerScript gameManagerScript;

    public float walkSpeed = 5f; // Speed while walking
    public float runSpeed = 10f; // Speed while running
    public float jumpForce = 400f; // Force applied for jumping
    private float _speedX; // For movement input

    private bool isGrounded; // To detect if the player is on the ground
    public bool isAlive = true;

    void Start()
    {
        gameManagerScript = FindObjectOfType<GameManagerScript>();
        if (gameManagerScript != null) 
        {
            Debug.Log("GameManager not found");
        }
    }

    void Update()
    {
        if (isAlive)
        {
            HandleMovement();
            GetCurrentState();
        }
        else
        {
            /*gameManagerScript.ReloadScene();*/
        }
        ShowDebuging();
        HandleAnimation();
    }

    private void HandleMovement()
    {
        // Get input
        _speedX = Input.GetAxis("Horizontal"); // Use A/D keys or arrow keys

        if (!IsGrounded())
        {
            animator.SetBool("Landed", false);
        }

        // Move the player horizontally
        Vector2 newPosition = new Vector2(_speedX * (IsRunning() ? runSpeed : walkSpeed), _rb.velocity.y);
        _rb.velocity = newPosition; // Update velocity for movement

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) // Only jump if grounded
        {
            PlayerJump();
            _rb.AddForce(new Vector2(0f, jumpForce)); // Apply an upward force for jumping
                                                      // Set jump animation
        }
        if (!isGrounded)
            animator.SetBool("IsJumping", true);

        if (IsGrounded())
        {
            animator.SetBool("IsJumping", false);
        }

        // Crouching
        if (Input.GetKey(KeyCode.LeftControl) && IsGrounded())
        {
            animator.SetBool("IsCrouching", true);
        }
        else
        {
            animator.SetBool("IsCrouching", false);
        }
    }

    private void HandleAnimation()
    {
        Vector3 scale = transform.localScale;

        animator.SetFloat("SpeedY", _rb.velocity.y);
        animator.SetBool("IsGrounded", IsGrounded());
        animator.SetBool("IsAlive", isAlive);

        if (_speedX != 0)
        {
            scale.x = Mathf.Sign(_speedX);
            transform.localScale = scale;
        }

        // Set the SpeedX parameter based on the horizontal input
        animator.SetFloat("SpeedX", Mathf.Abs(_speedX));

        // Set the running state
        animator.SetBool("IsRunning", IsRunning());
    }

    private bool IsRunning()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Player is on the ground
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // Player is not on the ground
        }
    }

    private bool IsGrounded()
    {
        return isGrounded; // Return the grounded status
    }

    private void PlayerJump()
    {
        _rb.AddForce(new Vector2(0f, jumpForce));
        if (!IsGrounded())
            animator.SetBool("IsJumping", true);
        else
            animator.SetBool("IsJumping", false);
    }

    private void ShowDebuging()
    {
        /*Debug.Log("Jumping :" + (animator.GetBool("IsJumping") ? "yes" : "no"));
        Debug.Log("Grounded: " + IsGrounded());*/
    }

    public void KillPlayer()
    {
        isAlive = false;
    }


    private void GetCurrentState()
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Player_Landing"))
        {
            // Check if the animation has finished (normalizedTime >= 1)
            if (stateInfo.normalizedTime >= 1)
            {
                animator.SetBool("Landed", true);
            }
        }
    }

    private bool DeathAnimComplete()
    {
        var animatorState = animator.GetCurrentAnimatorStateInfo(0);
        return !(animatorState.IsName("Death") && animatorState.normalizedTime < 1);
    }    
}