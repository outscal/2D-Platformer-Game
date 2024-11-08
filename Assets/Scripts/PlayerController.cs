using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private BoxCollider2D boxCol;
    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;

    private Rigidbody2D rb2d;

    public float speed;
    public bool jump; // Now jump is a boolean

    private bool isGrounded;

    public ScoreControlle scoreController;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        boxColInitSize = boxCol.size;
        boxColInitOffset = boxCol.offset;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        MoveCharacter(horizontal);
        PlayMovementAnimation(horizontal, vertical);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch(true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Crouch(false);
        }

        // Set jump to true if the player is trying to jump
        if (vertical > 0)
        {
            jump = true; // Set jump to true when trying to jump
        }
        else
        {
            jump = false; // Reset jump if not trying to jump
        }

        // Call to handle jump only when on ground
        MovePlayerVertically();
    }

    public void MovePlayerVertically()
    {
        // Check if we are on the ground and jump is true
        if (jump && isGrounded)
        {
            animator.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0, 10f), ForceMode2D.Impulse); // Example jump force
            isGrounded = false; // Prevent multiple jumps until grounded again
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.CompareTag("platform"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.CompareTag("platform"))
        {
            isGrounded = false;
        }
    }

    private void MoveCharacter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    private void PlayMovementAnimation(float speed, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;

        if (jump && isGrounded)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    public void Crouch(bool crouch)
    {
        if (crouch)
        {
            float offX = -0.0978f;     // Offset X
            float offY = 0.5947f;      // Offset Y

            float sizeX = 0.6988f;     // Size X
            float sizeY = 1.3398f;     // Size Y

            boxCol.size = new Vector2(sizeX, sizeY);   // Setting the size of collider
            boxCol.offset = new Vector2(offX, offY);   // Setting the offset of collider
        }
        else
        {
            // Reset collider to initial values
            boxCol.size = boxColInitSize;
            boxCol.offset = boxColInitOffset;
        }

        // Play Crouch animation
        animator.SetBool("Crouch", crouch);
    }

    public Heart_Health heartHealth;
    public void PickUpKey()
    {
        Debug.Log("Key picked UP");
        scoreController.IncreaseScore(5);
    }

    public void KillPlayer()
    {
        heartHealth.TakeDamage(1);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
