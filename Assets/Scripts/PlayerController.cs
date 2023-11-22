using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public float standingHeight = 1.0f;
    public float crouchHeight = 0.5f;
    public float standingOffset = 0.93f;
    public float crouchOffset = 0.5f;
    private BoxCollider2D playerCollider;
    public Animator animator;
    public float speed;
    public float Jump;

    public void PickUpKey()
    {
        Debug.Log("Key Picked Up!!");
        scoreController.IncreaseScore(20);
    }

    private Rigidbody2D rb;
    public float groundCheckRadius = 0.2f;
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
 