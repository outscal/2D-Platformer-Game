using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public Transform spawnPoint;
    public BoxCollider2D collider2d;
    public ScoreController scoreController;
    public HealthController healthController;
    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;
    public GameOverController gameOverController; // game over logic script
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isWalking;
    private float health;
   

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void KeyPicked()
    {
        scoreController.IncreaseScore(10); // Update UI
    }

    private void Start()
    {
        Respawn();
        
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        bool spacePressed = Input.GetKeyDown(KeyCode.Space);
        MoveAnimation(horizontal);
        MoveCharacter(horizontal, spacePressed);
        CheckForCrouch();
        CheckForJump(spacePressed);
        IsPlayerAlive();
        

    }

    private void IsPlayerAlive()
    {
        if (health <= 0)
        {
            PlayerDead(); // play death animation
            //Invoke("ResetLevel", 4f); // wait and reset the level
        }
    }

    private void MoveCharacter(float horizontal, bool spacePressed)
    {
        Vector2 _move = transform.position;
        // is player Walking or Running?
        _move.x = (isWalking) ? (_move.x + horizontal * walkSpeed * Time.deltaTime) : (_move.x + horizontal * runSpeed * Time.deltaTime) ;
        transform.position = _move; // update player position

        /*In Contrast to the video, this implementation actually work because the player has an RB
         and hence it falls back down to the earth.
        _move.y += vertical * jumpForce * Time.deltaTime;
         Just for consistency, using the implementation in the tutorial.*/
        if (spacePressed && isGrounded)
        {
            rb.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
        }
        if(Input.GetKey(KeyCode.LeftShift)) // if Shift Pressed, Player is RUNNING.
        {
            isWalking = false;
        }
        else
        {
            isWalking = true;
        }
    }

    private void MoveAnimation(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        // if horizontal is < 0 -> player is moving to the left -> rotate the player
        scale.x = (horizontal < 0) ? (-1) * Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    public void DecreaseHealth(float _damage)
    {
        
        if(health > 0)
        {
            health -= _damage;
            healthController.UpdateHealth(-_damage); //Update UI
        }
    }

    private void ResetLevel()
    {
        // load the current scene again
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
    }

    private void PlayerDead()
    {   
        // play the dead animation
        animator.SetBool("Dead", true);
        //activate the game over menu
        gameOverController.PlayerDied();
        this.enabled = false;
    }

    private void CheckForJump(bool spacePressed)
    {  
       if(spacePressed && isGrounded)
        {
            animator.SetTrigger("JumpTrigger");
        }
        animator.SetFloat("YVelocity", rb.velocity.y);
    }

    private void CheckForCrouch()
    {
        // if crouching, change collider size and play animation
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
            // hard coded values, observed from the Scene view.
            // ? What is the alternative where we need not depend on hard coded values?
            collider2d.size = new Vector2(0.6311399f, 1.327474f);
            collider2d.offset = new Vector2(0.01034069f, 0.5875177f);
        }
        else
        {
            animator.SetBool("Crouch", false);
            collider2d.size = new Vector2(0.6311399f,2.108599f);
            collider2d.offset = new Vector2(0.01034069f, 0.9780799f);
        }

    }

   
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            isGrounded = false;
        }
    }
    public void Respawn()
    {   
        // basic player stats initialization
        transform.position = spawnPoint.position;
        health = 50;
        walkSpeed = 3;
        runSpeed = 5;
        isWalking = true;
    }
}
