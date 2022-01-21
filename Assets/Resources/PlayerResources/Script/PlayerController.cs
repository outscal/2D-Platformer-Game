using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public Animator animator;

  public bool isCrouching;

  public bool Jumping;



    private void Awake() 
    {
      Debug.Log("Player controller awake");  
    }
  // private void OnCollisionEnter2D(Collision2D collision)
   //{
    //  Debug.Log("Collision:" + collision.gameObject.name);
 // }
 private void Update()
  {
      Movement();
  } 

  void Movement()
  {  
     float speed = Input.GetAxisRaw("Horizontal");
     animator.SetFloat("Speed", Mathf.Abs(speed));

     {
         Vector3 scale = transform.localScale;
         if(speed < 0)
         {
         scale.x = -1f * Mathf.Abs(scale.x);
         }
        else if(speed > 0)
        {
         scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
         if(Input.GetKeyDown(KeyCode.S))
        {
          animator.SetBool("Crouch",true);
          isCrouching = true;
         }
         else if(Input.GetKeyUp(KeyCode.S))
        {
          animator.SetBool("Crouch",false);
          isCrouching = false;
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
          animator.SetBool("Jump",true);
          Jumping = true;
         }
         else if(Input.GetKeyUp(KeyCode.W))
        {
          animator.SetBool("Jump",false);
          Jumping = false;
        }
    }

   }
}
