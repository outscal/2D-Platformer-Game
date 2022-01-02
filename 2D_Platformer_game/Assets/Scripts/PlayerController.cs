using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  public LayerMask groundLayerMask;
  public Animator animator;
  BoxCollider2D bc;
  public float speed;
  public float jump;
  public ScoreController scoreController;
  public GameOverController gameOverController;
  private Rigidbody2D rb2d;
  public List<GameObject> hearts ;
  public int heartcount = 3;


  //Awake
    private void Awake()
    {
        Debug.Log("Player Awake");
        bc = gameObject.GetComponent<BoxCollider2D>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

// Player Death Logic
 public void DamagePlayer()
 {
    if (heartcount > 0)
    {
     Destroy(hearts[0]);
      hearts.Remove(hearts[0]);
      heartcount--;
    }
    else
    {
        KillPlayer();
    }
 }
 public void KillPlayer()
    {
        
        animator.SetBool("Death",true);
        gameOverController.Playerdied();
        this.enabled = false;
        
       
    }

    

// ScoreHandler
    public void PickupKey()
    {
       
       scoreController.ScoreIncrease(10);
    }

// GroundChecker
  private bool IsGrounded()
    {
       float  extraheightcheck = .1f;
       RaycastHit2D raycastHit = Physics2D.Raycast(bc.bounds.center, Vector2.down, bc.bounds.extents.y + extraheightcheck,groundLayerMask);
        Color rayColor;

        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(bc.bounds.center, Vector2.down*(bc.bounds.extents.y + extraheightcheck));
        
        return raycastHit.collider != null;

    }
    
// Update
    private void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");

        HorizontalMovementAnimation(horizontal);
        VerticalMovementAnimation();
        MoveCharacterHorizontal(horizontal);
        MoveCharacterVertical();

     // Walk/Run Toggle
        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            animator.SetTrigger("Walk/Run Toggle");
        }

        PlayerCrouch();
    }

// CrouchHandler
    private void PlayerCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            animator.SetBool("Crouch", true);

            bc.size = new Vector2(0.5245454f, 1.269899f);
            bc.offset = new Vector2(-0.04246405f, 0.5954856f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {

            animator.SetBool("Crouch", false);

            bc.size = new Vector2(0.4168615f, 2.017859f);
            bc.offset = new Vector2(0.01137787f, 0.9694713f);
        }
    }
//Animation Handler_Horizontal
    private void HorizontalMovementAnimation(float horizontal )

       {
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
        }
//Animation Handler_Vertical
        private void VerticalMovementAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {


            animator.SetBool("Jump", true);
        }


        else
        {
            animator.SetBool("Jump", false);
        }
    }
    // Movement Handler_Horizontal
      private void MoveCharacterHorizontal(float horizontal)
       {
        
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
       }
   // Movement Handler_Vertical
       private void MoveCharacterVertical()
       {
         if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
         {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
            

         }
       }



      
     
    
}
 
      
         
        