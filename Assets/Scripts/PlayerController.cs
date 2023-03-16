using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

public Animator animator;
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

   //Run
    float horizontal= Input.GetAxisRaw("Horizontal");
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