using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public Animator animator; 

    private Rigidbody2D rb2d;

    public float speed;
    public float jump;
    
    private void Awake() 
    {
         rb2d =gameObject.GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
       float  hrzntl = Input.GetAxisRaw("Horizontal");
       float  vrtcl = Input.GetAxisRaw("Jump");

       PlayerAnimationBinding(hrzntl,vrtcl);
       MoveCharacter(hrzntl,vrtcl);

    }
     private void MoveCharacter(float horizontal,float vertical)
     {
       //for Horizontal movement
       Vector3 position = transform.position;
       position.x = position.x + horizontal * speed* Time.deltaTime;
       transform.position = position;

       //for jump movement
       if(vertical > 0)
       {
              rb2d.AddForce(new Vector2(0f,jump),ForceMode2D.Force);
       }
     }

     private void PlayerAnimationBinding(float horizontal, float vertical)
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

//jump
       if(vertical > 0)
       {
        //animator.SetFloat("Jump", Mathf.Abs(vertical));
        animator.SetBool("Jumpt",true);
       }
       else
       {
          animator.SetBool("Jumpt",false);    
       }
   
    }
    
};    