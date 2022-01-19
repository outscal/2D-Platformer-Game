using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
public Animator animator;
public float speed;
public float jumpSpeed;

public Rigidbody2D RB2D;
private void Awake() 
   {
      Debug.Log("Player controller awake");
      RB2D = gameObject.GetComponent<Rigidbody2D>();
   }
private void Update()
{
   float horizontal = Input.GetAxisRaw("Horizontal");
   float vertical = Input.GetAxisRaw("Jump");

   MoveCharacter(horizontal,vertical);
   PlayMovementAnimation(horizontal,vertical); 
}
private void MoveCharacter(float horizontal , float vertical)
{
   Vector2 position = transform.position;
   position.x = position.x + horizontal * speed * Time.deltaTime;
   transform.position = position;

   if (vertical > 0)
   {
      RB2D.AddForce(new Vector2(0f , jumpSpeed),ForceMode2D.Impulse);
   }
}
private void PlayMovementAnimation(float horizontal, float vertical)
{

animator.SetFloat("speed", Mathf.Abs(horizontal));

Vector2 scale = transform.localScale;
if(horizontal < 0)
   {
     scale.x = -1f * Mathf.Abs(scale.x);
   }
else if(horizontal > 0)
   {
      scale.x = Mathf.Abs(scale.x);
   }
   transform.localScale = scale;

   //to jump
   // if (vertical>0)
   // {
   //    animator.SetBool("Jump",true);
   // } 
   // else
   // {
   //    animator.SetBool("Jump",false);
   // }
   //if (Input.GetButtonDown("Jump"))
   //if (vertical > 0)
   if (Input.GetKeyDown(KeyCode.W))
   {
      animator.SetTrigger("Jump");
      RB2D.velocity = new Vector2(RB2D.velocity.x,jumpSpeed);
   }

   if (Input.GetKeyDown(KeyCode.S))
   {
      animator.SetBool("Crouch",true);
   }
   else if(Input.GetKeyUp(KeyCode.S))
   {
      animator.SetBool("Crouch",false);
   }
} 
}
