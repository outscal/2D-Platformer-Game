using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
  public Animator animator;

  public float speed;

  public float jump;

  public bool crouching;

  public Rigidbody2D rigidboddy2D;

  private void Awake() 
    {
      Debug.Log("Player controller awake");
      rigidboddy2D = gameObject.GetComponent<Rigidbody2D>();     
    }
  // private void OnCollisionEnter2D(Collision2D collision)
   //{
    //  Debug.Log("Collision:" + collision.gameObject.name);
 // }
 private void Update()
  {
      float horizontal = Input.GetAxisRaw("Horizontal");
      float vertical = Input.GetAxisRaw("Jump");

      MoveCharacter(horizontal, vertical);
      PlayMovementAnimations(horizontal, vertical);
  }
  private void MoveCharacter(float horizontal, float vertical)
  {
      // move character horizontally
      Vector3 position = transform.position;
      //speed (distance / per time) * Time.deltaTime(frames/per time)
      position.x += horizontal * speed * Time.deltaTime;
      transform.position = position;

      // move character vertically
      if(vertical > 0)
      {
          rigidboddy2D.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
      }
  }   


  private void PlayMovementAnimations(float horizontal, float vertical)
  {
    
      animator.SetFloat("Speed", Mathf.Abs(horizontal));
      Vector3 scale = transform.localScale;
      if(horizontal < 0)
      {
        scale.x = -1f * Mathf.Abs(scale.x);
      }
      else if (horizontal > 0)
      {
      scale.x = Mathf.Abs(scale.x);
      transform.localScale = scale;
      }
         //crouching
      else if(Input.GetKeyDown(KeyCode.C))
      {
      animator.SetBool("Crouch",true);
      crouching = true;
      }
      else if(Input.GetKeyUp(KeyCode.C))
      {
      animator.SetBool("Crouch",false);
      crouching = false;
      }
       //jump
      else if(vertical > 0)
      {
          animator.SetBool("Jump", true);
      }
      else
      {
          animator.SetBool("Jump",false);
      }
  } 
}
  
  