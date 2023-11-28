using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameOverController gameOverController;
    public ScoreController scoreController;
    public float standingHeight = 1.0f;
    public float crouchHeight = 0.5f;
    public float standingOffset = 0.93f;
    public float crouchOffset = 0.5f;
    private BoxCollider2D playerCollider;
    public Animator animator;
    public float MaxHeart = 3;
    public float currentHearts;
    private bool isHurt = false;



    public void KillPlayer()
    {
        Debug.Log("Player killed by enemy");
        animator.SetBool("Die", true);
        gameOverController.PlayerDied();
        this.enabled = false;
    


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>() != null && !isHurt)
        {

            Debug.Log("Player hit by enemy!");
       
            animator.SetBool("IsHurt", true);
            isHurt = true;


            // Start a coroutine to reset the hurt state after a delay (e.g., 1 second).
            StartCoroutine(ResetHurtState());

            HealthManager.Health--;
           

        }
    }

    void LoseHeart()
    {
        currentHearts--;

        if (currentHearts <= 0)
        {
            // Player has no more hearts, trigger game over.
            Debug.Log("Player lost all hearts - Game Over!");

        }
    }

        private IEnumerator ResetHurtState()
    {
        yield return new WaitForSeconds(0.2f);

        // Reset hurt animation and state.
        animator.SetBool("IsHurt", false);
        isHurt = false;
    }

    public void takeDamage(int damage)
    {
        currentHearts -= damage;
        
        if (currentHearts <= 0)
        {
            KillPlayer();
        }

    }

 

    public float speed;
    public float Jump;

    public void PickUpKey()
    {
        Debug.Log("Key Picked Up!!");
        scoreController.IncreaseScore(20);
    }

    private Rigidbody2D rb;
    public float groundCheckRadius = 0.4f;
    private bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        currentHearts = MaxHeart;
        animator = GetComponent<Animator>();



    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        float horizontal = Input.GetAxisRaw("Horizontal");
     

        MoveCharacter(horizontal);


        PlayerCrouchAnimation();

        PlayerJumpAnimation();

        PlayerMovementAnimation(horizontal);



        void MoveCharacter(float horizontal)
        {
            Vector3 position = transform.position;
            position.x = position.x +horizontal * speed * Time.deltaTime;
            transform.position = position;   
            
        }

        void PlayerMovementAnimation(float horizontal)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            Vector3 scale = transform.localScale;
            if (horizontal < 0)
            {
                scale.x = -1f * Mathf.Abs(scale.x);
            }
            else if (horizontal > 0)
            {
                scale.x = Mathf.Abs(scale.x);
            }
            transform.localScale = scale;
        }



        void PlayerCrouchAnimation()
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                animator.SetBool("crouch", true);
                playerCollider.size = new Vector2(playerCollider.size.x, crouchHeight);
                playerCollider.offset = new Vector2(playerCollider.offset.x, crouchOffset);

            }
            else if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                animator.SetBool("crouch", false);
                playerCollider.size = new Vector2(playerCollider.size.x, standingHeight);
                playerCollider.offset = new Vector2(playerCollider.offset.x, standingOffset);

            }
        }

        void PlayerJumpAnimation()
        {

            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                animator.SetBool("Jump", true);
                rb.AddForce(new Vector2(0f, Jump), ForceMode2D.Impulse);
            }
            else
            {
                animator.SetBool("Jump", false);
            }
        }


    }
}
 