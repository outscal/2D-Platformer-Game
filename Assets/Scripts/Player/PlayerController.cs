using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    private GameOverController gameOverController;
    private DeathController deathController; 

    public Animator playerAnimator;

    public float speed;
    public float jump;

    public bool isGrounded; 

    private Rigidbody2D rb; 

    private Vector2 standingColliderOffset = new Vector2(0f, 0.98f);
    private Vector2 standingColliderSize = new Vector2(0.45f, 2.05f);
    private Vector2 crouchingColliderOffset = new Vector2(-0.15f, 0.6f);
    private Vector2 crouchingColliderSize = new Vector2(0.75f, 1.3f);


    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();     
    }
    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        PlayerMovementAnimation(horizontal, vertical);
        MoveCharacter(horizontal, vertical);       
    }

    public void KillPlayer()
    {
        playerAnimator.SetTrigger("Death");

        deathController.PlayerDied(); 
        gameOverController.GameOver();  
    }

    public void PickUpKey()
    {
        scoreController.IncreaseScore(10); 
    }

    private void PlayerMovementAnimation(float horizontal, float vertical)
    {

        //Move horizontally to Walk/Run
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontal));

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


        //Jump
        //if (Input.GetKey(KeyCode.Space) && isGrounded)
        if (vertical > 0)
        {
            playerAnimator.SetBool("Jump", true);
            Debug.Log("Jump anim playing");
        }
        else
        {
            playerAnimator.SetBool("Jump", false);
        }

        //Crouch
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            playerAnimator.SetBool("Crouch", true);

            GetComponent<BoxCollider2D>().offset = crouchingColliderOffset;
            GetComponent<BoxCollider2D>().size = crouchingColliderSize;
        }
        else
        {
            playerAnimator.SetBool("Crouch", false);

            GetComponent<BoxCollider2D>().offset = standingColliderOffset;
            GetComponent<BoxCollider2D>().size = standingColliderSize;
        }

    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        //move character horizontally
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //move character vertically
        //if (vertical > 0 && isGrounded)
        if (vertical > 0)
        {
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Grounded"); 
        if (collision.transform.tag == "Platform")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Not Grounded");
        if (collision.transform.tag == "Platform")
        {
            isGrounded = false;
        }
    }

}
