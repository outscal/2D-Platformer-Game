using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public Animator animator;     // Animator class animator is object   (its from Unity)
     private Rigidbody2D rb;       // Rigidbody2D is a class   (its from Unity)
     public float speed;
     /*private void Awake()
     {
        Debug.Log("Player Controller awake");  
     }
        private void OnCollisionEnter2D(Collision2D collision) 
        {
          Debug.Log("Collision: " + collision.gameObject.name);
        }*/

      private void Start()       // its from unity
    {
      animator = GetComponent<Animator>();
      rb = GetComponent<Rigidbody2D>();
    }

     private void Update()
    {
        PlayMovementAnimation();
        setCrouch();
        setJump();
    } 

    private void PlayMovementAnimation()
    {
      float horizontal = Input.GetAxisRaw("Horizontal");      //Key A= -1, Key D = 1

      transform.position = transform.position + new Vector3(horizontal,0,0)*speed*Time.deltaTime;   // Changing position
          animator.SetFloat("Speed", Mathf.Abs(horizontal));

          Vector3 scale = transform.localScale;
          if(horizontal<0)                                  // its for flipping negative
          {
              scale.x = -1f * Mathf.Abs(scale.x);
          }
          else if (horizontal>0)                            // its for flipping positive
          {
              scale.x = Mathf.Abs(scale.x);
          }
              transform.localScale = scale;  
    }

  
    void setCrouch()    // Crouch fuction
    { 
       if (Input.GetKeyDown(KeyCode.C))
       {
        animator.SetBool("Crouch", true);
       }

       if (Input.GetKeyUp (KeyCode.C))
       {
         animator.SetBool("Crouch", false);
       }
    }

    void setJump()     // Jump function
    {
        float vertical = Input.GetAxisRaw("Jump");  
       if(vertical>0)
       {
       animator.SetBool("Jump", true );
       }
       else
       {
         animator.SetBool("Jump", false);
       }
    }

}
