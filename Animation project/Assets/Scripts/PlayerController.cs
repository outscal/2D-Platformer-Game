using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
        
   
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

      if(Input.GetKeyDown("s"))
        {
            animator.Play("Player_crouch");
        }

        if(Input.GetKeyDown("w"))
        {
            animator.Play("Player_Jump");
        }
 }
       
   }
}
