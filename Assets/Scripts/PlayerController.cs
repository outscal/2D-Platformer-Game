using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D collider2d;
    public float speed;
    private Rigidbody2D rb;
    private bool isGrounded;
    public float jumpForce;
    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        MoveAnimation(horizontal);
        MoveCharacter(horizontal, vertical);
        CheckForCrouch();
        CheckForJump();

    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector2 _move = transform.position;
        _move.x += horizontal * speed * Time.deltaTime;
        transform.position = _move;
        // In Contrast to the video, this implementation actually work because the player has an RB
        // and hence it falls back down to the earth.
        //_move.y += vertical * jumpHeight * Time.deltaTime;
        // Just for consistency, using the implementation in the tutorial.
        if(vertical>0 && isGrounded)
        {
            rb.AddForce(new Vector2(0,jumpForce), ForceMode2D.Force);
        }

    }

    private void MoveAnimation(float horizontal)
    {
        
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = (-1) * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    private void CheckForJump()
    {
        
       if(Input.GetKeyDown(KeyCode.Space))
       //if(vertical > 0)
        {
            animator.SetTrigger("JumpTrigger");
            Debug.Log("Jump Triggered");
            //animator.SetBool("Jump", true);
        }
        /*else
        {
            //animator.SetBool("Jump", false);
        }*/
    }

    private void CheckForCrouch()
    {
     
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
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

    //make sure u replace "floor" with your gameobject name.on which player is standing
     void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.name == "Platform")
        {
            Debug.Log("I am in Enter");
            isGrounded = true;
        }
    }

    //consider when character is jumping .. it will exit collision.
     void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Platform")
        {
              isGrounded = false;
        }
    }
}
