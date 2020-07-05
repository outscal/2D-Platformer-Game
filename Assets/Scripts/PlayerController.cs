using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float jump;
    public float moveSpeed;

    private Rigidbody2D rigidbody;
    private BoxCollider2D collider;
    

    private bool isInGround;


    private Vector2 startingColliderSize;
    private Vector2 startingColliderOffset;

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

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        Move(horizontal,vertical);

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
            

        }
        else if(Input.GetKey(KeyCode.LeftControl))
        {
            collider.size = new Vector2(1.0f, 1.4f);
            collider.offset = new Vector2(-0.12f, 0.62f);

        }
        else
        {
            animator.SetBool("Crouch", false);
            collider.size = startingColliderSize;
            collider.offset = startingColliderOffset;
        }

    }

    private void Move(float horizontal,float vertical)
    {
        // Moving horizontal
        Vector2 position = transform.position;
        position.x += horizontal * moveSpeed * Time.deltaTime;
        transform.position = position;

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector2 scale = transform.localScale;

        if (horizontal < 0 || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(horizontal> 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;


        // Jump animation
        if (vertical > 0 && isInGround)
        {
            
            animator.SetBool("Jump", true);
            rigidbody.AddForce(Vector2.up*jump);
            
        }

           
        else
        {
            animator.SetBool("Jump", false);
            collider.offset = startingColliderOffset;
        }


        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Jump", true);
            rigidbody.AddForce(new Vector2(0, jump), ForceMode2D.Force);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Jump", false);
        }*/
    }

    private void OnCollisionEnter2D(Collision2D other)          
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isInGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isInGround = false;
        }
    }
}
