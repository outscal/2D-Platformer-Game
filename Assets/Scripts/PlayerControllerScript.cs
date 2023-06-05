using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public Animator animator; 

    private Rigidbody2D rb2d;

    public float speed;
    public float jump;
    public bool IsGrounded ;
    public bool IsJumping;
    private void Awake() 
    {  
       rb2d =gameObject.GetComponent<Rigidbody2D>(); 
    }
    


    // Update is called once per frame
    void Update()
    {
       float  hrzntl = Input.GetAxisRaw("Horizontal");
       if( Input.GetButtonDown("Jump"))
       {
               IsJumping =true;
               if(IsGrounded)
               {
                  Jump();
               }
       }
       

       PlayerAnimationBinding(hrzntl);
       MoveCharacter(hrzntl);
       

    }
     private void MoveCharacter(float horizontal)
     {
       //for Horizontal movement
       Vector3 position = transform.position;
       position.x = position.x + horizontal * speed* Time.deltaTime;
       transform.position = position;

      
     }

     private void PlayerAnimationBinding(float horizontal)
    {
         animator.SetFloat("Speed",Mathf.Abs(horizontal));

       Vector3 resize = transform.localScale;
       if(horizontal < 0)
       {
        resize.x = -1f * Mathf.Abs(resize.x);
       }
       else if(horizontal > 0)
       {
        resize.x = Mathf.Abs(resize.x);
       }
       transform.localScale = resize;

//crouch
       if(Input.GetKeyDown("left ctrl"))
       {
              animator.SetBool("Crouch",true);
       }
       else  if(Input.GetKeyUp("left ctrl"))
       {
              animator.SetBool("Crouch",false);
       }
       animator.SetBool("IsGrounded",IsGrounded);
    }
    private void OnCollisionStay2D(Collision2D other) 
    {
       if(other.transform.tag == "Platform")
       {
             IsGrounded  = true; 
       }
    }
    private void OnCollisionExit2D(Collision2D other) {
       if(other.transform.tag=="Platform")
       {
              IsGrounded = false;
       }
    }
    
    private void Jump()
    {
       rb2d.AddForce(new Vector2(0,jump),ForceMode2D.Impulse);
       
    }
    private void OnCollisionEnter2D(Collision2D other) {
       if(other.transform.tag=="Platform")
       {
              IsJumping=false;
       }

    }
};    