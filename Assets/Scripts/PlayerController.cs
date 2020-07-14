using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float jumpSpeed;
    public float doubleJumpSpeed;
    public float moveSpeed;
    public int keysCollected = 0;
    private Rigidbody2D rigidbody;
    private BoxCollider2D collider;
    private Vector2 spawnPosition;

    public ScoreController scoreController;
    public UIManager uiManager;
    private int groundLayer = 9;
    private int alienBlockLayer = 12;

    private bool IsOnGround;
    private bool canDoubleJump;

    private int lives = 3;


    private Vector2 startingColliderSize;
    private Vector2 startingColliderOffset;
    private Vector2 newColliderSize = new Vector2(1.0f, 1.4f);
    private Vector2 newColliderOffset = new Vector2(-0.2f, 0.62f);

    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        collider = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        startingColliderSize = collider.size;
        startingColliderOffset = collider.offset;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Move(horizontal);
        Jump();
        Crouch();
    }


    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && IsOnGround)
        {
            animator.SetBool("Jump", true);
            rigidbody.velocity = Vector2.up * jumpSpeed;

        }

        else if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
        {
            animator.SetBool("Jump", true);
            rigidbody.velocity = Vector2.up * doubleJumpSpeed;
            canDoubleJump = false;
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void Move(float horizontal)
    {
        Vector2 position = transform.position;
        position.x += horizontal * moveSpeed * Time.deltaTime;
        transform.position = position;

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector2 scale = transform.localScale;

        if (horizontal < 0 || Input.GetKeyDown(KeyCode.LeftArrow))   // left arrow is used to change its direction
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }


    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
            collider.size = newColliderSize;
            collider.offset = newColliderOffset;

        }

        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
            collider.size = startingColliderSize;
            collider.offset = startingColliderOffset;
        }
    }



    public void PickUpKey()
    {
        keysCollected += 1;
        scoreController.AddScore(10);
    }



    public void PlayerDied()
    {
        lives--;
        uiManager.DecrementLives();
        if (lives > 0)
        {
            transform.position = spawnPosition;
            
        }
        else
        {
            StartCoroutine("RestartLevel");
            animator.SetBool("Died", true);
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
        
        
    }


    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2);
        uiManager.AwakeGameOverPanel();
    }



    private void OnCollisionEnter2D(Collision2D other)          
    {
        if(other.gameObject.layer == groundLayer || other.gameObject.layer == alienBlockLayer)
        {
            IsOnGround = true;
            canDoubleJump = true;
 
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.layer == groundLayer || other.gameObject.layer == alienBlockLayer)
        {
            IsOnGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        spawnPosition = transform.position;
    }
}
