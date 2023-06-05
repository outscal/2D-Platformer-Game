using System;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public GameOverController gameoverController;
    public KeyScoreController keyscoreController;
    public Animator animator;
    public float speed;
    private Rigidbody2D rb2D;
    public float jumpForce = 5f;
    private bool isJumping = false;
    private bool isGrounded; 
    private bool isCrouching;



    private void Awake()
    {
        Debug.Log("Player Controller Awake");
        rb2D = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {   // PlayerMovement
        float horizontal = Input.GetAxisRaw("Horizontal");
        MoveCharacter(horizontal);
        PlayerMovementAnimation(horizontal);           
           

        //Player Jump
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        //Crouch
        PlayerCrouchAnimation();
    }

    private void MoveCharacter(float horizontal)
    {
        //RunMove
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    private void PlayerMovementAnimation(float horizontal)
    {
        // RUN
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if ((Mathf.Abs(horizontal) > 0f) && isGrounded && !isJumping &&!isCrouching)
        {
            SoundManager.Instance.PlayMusic(Sounds.Footsteps);
        }

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

    private void Jump()
    {
        // Jump
        rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        animator.SetTrigger("Jump");
        SoundManager.Instance.Play(Sounds.PlayerMoveJump);
        isJumping = true;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (isJumping)
            {
                SoundManager.Instance.Play(Sounds.PlayerMoveJumpLand);
                isJumping = false;
            }
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void PlayerCrouchAnimation()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetTrigger("Crouch");
            isCrouching = true;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))

        {
            isCrouching = false;
        }
     
    }

    internal void KillPlayer()
    {
        Debug.Log("Player hit by the Enemy");
        animator.SetBool("Death", true);
        gameoverController.PlayeDied();
        this.enabled = false;
    }   

    public void PickUpKey()
    {
        Debug.Log("Player picked up the Key");
        keyscoreController.IncreaseScore(10);
    }
       
}
