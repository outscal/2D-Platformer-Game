using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    private Rigidbody2D rb2d;
    public float speed;
    public float jump;
<<<<<<< Updated upstream
=======
    
    public isGrounded isPlayerGrounded;//is Player Grounded
    /*private bool falling = false;
    private bool playerDead = false;*/
    public ScoreController scoreController;//Score Controller
    public HealthController _healthController;//Health Controller
    private SpriteRenderer spriteR;


    public void PickUpKey()
    {
        //Debug.Log("Player Picked Up the Key");
        scoreController.IncreaseScore(10);
    }
    //Player death
    public void playerDeathAnimation()
    {
        //Debug.Log("Player Dead");
        animator.SetBool("Fall", true);
        
        //Camera.main.transform.parent = null; // unchild from player. Keeps same position in world
        //Destroy(gameObject); // player kills itself
    }

  
    public BoxCollider2D collider;

    public Vector2 standingSize;
    public Vector2 sCrouchingOffset;
    public Vector2 crouchingSize;
    public Vector2 crouchingOffset;




>>>>>>> Stashed changes


    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        
=======
        playerRigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        
        


>>>>>>> Stashed changes
    }

   

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal, vertical);
        PlayerAnimationMovement(horizontal, vertical);
=======
        if(_healthController.playerHealth > 0)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Jump");
            MoveCharacter(horizontal, vertical);
            PlayerAnimationMovement(horizontal, vertical);
            PlayerCrouch();
        }
        
        
        //Debug.Log("Vertical: " +vertical);
>>>>>>> Stashed changes

       

    }

    //Character Movement
    private void MoveCharacter(float horizontal, float vertical)
    {
        //horizontal
        Vector3 position = transform.position;
        position.x += horizontal *speed * Time.deltaTime;
        transform.position = position;

        //vertical
       if(vertical > 0 && isPlayerGrounded.isOnGrounded == true)
       {
           rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
       }

       //FallDeath
       /*if(isOnDG.isOnDeathGrounded == true)
       {
           Application.LoadLevel(0);
       }*/
    }
    //Player Movement Animation 
    private void PlayerAnimationMovement(float horizontal, float vertical)
    {
        //Animation : actual player movement along x axis
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

         //Jump animation along y axis
        if(vertical > 0 )
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
<<<<<<< Updated upstream
    }
=======

       /* //Death if player falling from ground
        if(transform.position.y < 0)
        {
            animator.SetBool("Fall", true);
        }
        else
        {
            animator.SetBool("Fall", false);
        }*/

    }

    //Crouch

    private void PlayerCrouch()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {

            // spriteR.sprite = Crouching;
            animator.SetBool("Crouch", true);
            collider.size = crouchingSize;
            collider.offset = crouchingOffset;
        }

        if(Input.GetKeyUp(KeyCode.C))
        {
            animator.SetBool("Crouch", false);
            //spriteR.sprite = Standing;
            collider.size = standingSize;
            collider.offset = sCrouchingOffset;
        }
    }

    // //isGrounded

    // private void isGrounded()
    // {
    //     public bool isOnGrounded = false;
    //     private void OnTriggerEnter2D(Collider2D other)
    //     {
    //         if(other.gameObject.tag == "floor")
    //         {
    //             isOnGrounded = true;
    //         }
    //     }

    //     private void OnCollisionExit2D(Collision2D col)
    //     {
    //         isOnGrounded = false;
    //     }
    // }



//var falling: boolean = false; // tells when the player is falling private var lastY: float; // last grounded height private var character: CharacterController;

// function Start()
// { 
// character = GetComponent(CharacterController); 
// lastY = transform.position.y; 
// }

// function Update()
//     { 
//         if (character.isGrounded == false)
//         { 
//         // if character not grounded... 
//         falling = true; 
//         // assume it's falling 
//         } 
//         else 
//         { 
            // if character grounded... 
//             if (falling)
//             { 
//                 // but was falling last update... 
//                 var hFall = lastY - transform.position.y; 
//                 // calculate the fall height... 
//                 if (hFall > 8)
//                 { 
//                     // then check the damage/death 
//                     // player is dead 
//                 } 
//             } 
//             lastY = transform.position.y; // update lastY when character grounded 
//         } 
//     }
>>>>>>> Stashed changes
}
