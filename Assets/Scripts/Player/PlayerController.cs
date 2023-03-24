using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float HorizontalInput;

    private Animator playerAnim;
    private Vector3 temp;
   
    private BoxCollider2D playerCollider;

    // Coliider sizes  Before and After Crouch.......................
    private Vector2 OriginalCollideSize = new Vector2(0.4f, 2f), OriginalOffset = new Vector2(-0.004f, 0.96f);

    private Vector2 CrouchCollideSize = new Vector2(0.58f, 1.31f), CrouchOffset = new Vector2(-0.004f, 0.6f);
     // Coliider sizes  Before and After Crouch.......................

    public float playerSpeed;

    private Rigidbody2D playerRb;

    public float jumpForce;
    private float jumpInput;
    private bool isGrounded=true;

    private ScoreUI scorevar;
    private int scoreRaise=5;
  //  public PlayeHealth playerHealth;
    private void Awake()
    {
       scorevar = GameObject.FindGameObjectWithTag("UiController").GetComponent<ScoreUI>();

         playerAnim = gameObject.GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();
        playerRb = GetComponent<Rigidbody2D>();
    }
 

    // Update is called once per frame
    void Update()
    {      
            HorizontalInput = Input.GetAxis(HelperNames.HorizontalAxis);

            PlayerMoveAnimations();

            Crouch();
            PlayerJump(isGrounded);
            PlayerMove(HorizontalInput);

            Jump();
    }

    public void KeyCollected()
    {
        scorevar.ScoreController(scoreRaise);
    }

    public void PlayerMove(float inputHorizontal)
    {
       
            float playerPos = this.transform.position.x;
            playerPos+= HorizontalInput * playerSpeed * Time.deltaTime;
            this.transform.position = new Vector3(playerPos,transform.position.y,transform.position.z);
            
        
    }
    public void PlayerMoveAnimations()
    {

        

        playerAnim.SetFloat("Speed", Mathf.Abs(HorizontalInput));
        // Flip Player Left Right.......

        temp = this.transform.localScale;
        if (HorizontalInput > 0)
        {
            temp.x = Mathf.Abs(temp.x);
        }
        else if (HorizontalInput < 0)
        {
            temp.x = -1f * Mathf.Abs(temp.x);
        }

        this.transform.localScale = temp;


    }


    public void PlayerJump(bool isGrounded)
    {
        if(isGrounded==true)
        {
            playerAnim.SetBool("Jump",false);
        }


        else if (isGrounded == false)
        {
                   
                     playerAnim.SetBool("Jump", true);
                }
    }
   
    public void Crouch()
    {
       
       
        if (Input.GetKey(KeyCode.LeftControl)) 
        {
            
            
            playerCollider.size = CrouchCollideSize;
            playerCollider.offset = CrouchOffset;
          

            playerAnim.SetBool("Crouch",true);
          
        }
        else
        {
            playerAnim.SetBool("Crouch", false);
        
            playerCollider.size = OriginalCollideSize;
            playerCollider.offset = OriginalOffset;
           
           
            
        }


    }

    public void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (playerRb.velocity.y <= 0&& isGrounded)
            {
                SoundManager.Instance.PlaySounds(Sounds.Jump);
                playerRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isGrounded = false;
           }

        }
        
 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        
        }

        
    }


   

}
