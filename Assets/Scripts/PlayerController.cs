using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator animator;
    public float speed;
    public float jumpForce;
    private bool isGrounded = true;
    private bool isCrouching = false;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCol;
    private float colliderSizeInX = 0.52f;
    private float colliderSizeInY = 1.24f;
    private float colliderOffsetInX = -0.0041f;
    private float colliderOffsetInY = 0.5665f;

    private void Awake()
    {
        Debug.Log("Player controller awake");
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        boxCol = this.GetComponent<BoxCollider2D>();
    }
    
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Debug.Log("Collision: " + collision.gameObject.name);
    // }

    private void Update()
    {
        //for running animation
        float horizontalInput = Input.GetAxisRaw("Horizontal");       
        float verticalInput = Input.GetAxisRaw("jump");               

        MoveCharacter(horizontalInput, verticalInput);
        PlayMovementAnimation(horizontalInput, verticalInput);
        Crouch(isCrouching);
    }

    private void MoveCharacter(float horizontalInput, float verticalInput)
    {
        //move character horizontally 
        Vector3 position = transform.position;
        position.x += horizontalInput * speed * Time.deltaTime;  //learn
        transform.position = position;

        //move chararcter vertically
        if (verticalInput > 0 && isGrounded)
        {
            rigidbody2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void PlayMovementAnimation(float horizontalInput, float verticalInput)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        Vector3 scale = transform.localScale;
        if(horizontalInput < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if(horizontalInput > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Jump
        if(verticalInput > 0)                         
        {
            animator.SetBool("Jump", true); 
            animator.SetFloat("Speed", 0);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void Crouch(bool crouch)
    {
        crouch = isCrouching;
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isCrouching = true;
            animator.SetBool("Crouch", isCrouching);
            boxCol.size = new Vector3(colliderSizeInX, colliderSizeInY);
            boxCol.offset = new Vector3(colliderOffsetInX, colliderOffsetInY);
        }
        else 
        {
            isCrouching = false;
            animator.SetBool("Crouch", isCrouching);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true; 
        } 
    }
    
    public void PickUpKey()
    {
        Debug.Log("Player picked up the key");
        scoreController.IncreaseScore(10);
    }

    public void KillPlayer()
    {
       Debug.Log("Player killed by enemy");
       //Destroy(gameObject);
       //Play the death animation
    }
}