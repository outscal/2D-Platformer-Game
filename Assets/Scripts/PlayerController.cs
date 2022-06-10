using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public Transform spawnPoint;
    public BoxCollider2D collider2d;
    public ScoreController scoreController;
    public float walkSpeed;
    public float runSpeed;
    private Rigidbody2D rb;
    private bool isGrounded;
    public float jumpForce;
    private bool isWalking;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void KeyPicked()
    {
        Debug.Log("Player got a key!");
        scoreController.IncreaseScore(10);
    }

    private void Start()
    {
        Respawn();
        walkSpeed = 3;
        runSpeed = 5;
        isWalking = true;
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        bool spacePressed = Input.GetKeyDown(KeyCode.Space);
        MoveAnimation(horizontal);
        MoveCharacter(horizontal, spacePressed);
        CheckForCrouch();
        CheckForJump(spacePressed);

    }
    private void MoveCharacter(float horizontal, bool spacePressed)
    {
        Vector2 _move = transform.position;
        _move.x = (isWalking) ? (_move.x + horizontal * walkSpeed * Time.deltaTime) : (_move.x + horizontal * runSpeed * Time.deltaTime) ;
        transform.position = _move;
        /*In Contrast to the video, this implementation actually work because the player has an RB
         and hence it falls back down to the earth.
        _move.y += vertical * jumpForce * Time.deltaTime;
         Just for consistency, using the implementation in the tutorial.*/
        if (spacePressed && isGrounded)
        {
            rb.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
        }
        if(Input.GetKey(KeyCode.LeftShift))
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

    //make sure u replace "floor" with your gameobject name.on which player is standing
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }

    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            isGrounded = false;
        }
    }
    public void Respawn()
    {
        transform.position = spawnPoint.position;
    }
}
