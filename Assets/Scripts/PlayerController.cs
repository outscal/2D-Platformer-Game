using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

public Animator animator;
public float speed;
  private void Awake() 
  {
    Debug.Log("Player controller is Awake");
 }


 // private void OnCollisionEnter2D(Collision2D collision) 
 // {
 //  Debug.Log("Collision: " + collision.gameObject.name);
 //  }

    private void Update()
   {

    float horizontal= Input.GetAxisRaw("Horizontal");
    MoveCharacter(horizontal);
    PlayerMovementAnimation(horizontal);
    
   }


//MOVEMENT
   private void MoveCharacter(float horizontal)
{

Vector3 position = transform.position;
position.x += horizontal * speed * Time.deltaTime;
transform.position = position;

  }


//ANIMATION
private void PlayerMovementAnimation(float horizontal)
{
   animator.SetFloat("Speed", Mathf.Abs(horizontal));


//Run
    Vector3 scale= transform.localScale;
    if (horizontal < 0)
    {
        scale.x= -1f * Mathf.Abs(scale.x);
    }

else if (horizontal > 0)
 {
       scale.x= Mathf.Abs(scale.x);
   
}

transform.localScale = scale;

//Jump
float vertical= Input.GetAxisRaw("Jump");

if (Input.GetButtonDown("Jump"))
{
animator.SetBool("Jump", true);
}
else if (Input.GetButtonUp("Jump"))
{
animator.SetBool("Jump", false);
}  
 

//Crouch
bool crouch= Input.GetKeyDown(KeyCode.LeftControl);

 if (Input.GetKeyDown(KeyCode.LeftControl))
{
animator.SetBool("Crouch", true);
}
else if (Input.GetKeyUp(KeyCode.LeftControl))
{
animator.SetBool("Crouch", false);
}   
  }





}

