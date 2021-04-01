using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //State variables
    public Animator animator;
    public float speed;
    public float jump   ;

    //Cached references
    BoxCollider2D boxCollider;
    Rigidbody2D rb2d;
    
    //bool
    bool isCrouch;
    bool isJump;
    bool isGrounded;

    private void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        Debug.Log("Collision : " + collision.gameObject.name + " is grounded =  " + isGrounded);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        float crouch = Input.GetAxisRaw("Crouch");
        MoveCharacter(horizontal, vertical, crouch);
        PlayerMovementAnimation(horizontal, vertical, crouch);
        BoxColliderChanger();

    }

    private void BoxColliderChanger()
    {
        if (!isCrouch && isJump)
        {
            boxCollider.offset = new Vector2(0.15f, 1.75f);
            boxCollider.size = new Vector2(0.86f, 1.45f);
        }
        else if (isCrouch && !isJump)
        {
            boxCollider.offset = new Vector2(-0.17f, 0.60f);
            boxCollider.size = new Vector2(0.88f, 1.38f);
        }
        else
        {
            boxCollider.offset = new Vector2(0.024f, 1.01f);
            boxCollider.size = new Vector2(0.62f, 2.07f);
        }
    }

    private void MoveCharacter(float horizontal, float vertical, float Crouch)
    {
        //moving player
        if (!isCrouch)
        {
            Vector3 playerPos = transform.position;
            playerPos.x += horizontal * speed * Time.deltaTime;
            transform.position = playerPos;
        }

        if (vertical>0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }
    private void PlayerMovementAnimation(float hSpeed,float vSpeed,float crouch)
    {
        PlayerMovementAnimationXAxis(hSpeed);

        PlayerMovementAnimationYAxis(vSpeed, crouch);

    }

    private void PlayerMovementAnimationYAxis(float vSpeed, float crouch)
    {
        //Jump
        if (vSpeed > 0 && isGrounded)
        {
            isJump = true;
            isGrounded = false;
            animator.SetBool("Jump", true);
            Debug.Log(isGrounded);
            
        }
        else if (vSpeed <= 0)
        {
            isJump = false;
            animator.SetBool("Jump", false);
           
        }

        //Crouch
        if (crouch > 0)
        {
            if (isGrounded)
            {
                isCrouch = true;
                Debug.Log("ctrl detected");
                animator.SetBool("isCrouch", true);
            }
        }
        else if (crouch <= 0)
        {
            isCrouch = false;
            animator.SetBool("isCrouch", false);
        }
    }

    private void PlayerMovementAnimationXAxis(float hSpeed)
    {
        //run left and right
        animator.SetFloat("Speed", Mathf.Abs(hSpeed));
        Vector3 scale = transform.localScale;
        if (hSpeed < 0)
        {
            scale.x = -1f * Mathf.Abs(hSpeed);
        }
        else if (hSpeed > 0 )
        {
            scale.x = Mathf.Abs(hSpeed);
        }
        transform.localScale = scale;
    }
}
