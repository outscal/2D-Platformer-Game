// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//   public Animator animator;
//   public Rigidboddy2D rb2D;
//   public float moveSpeed;
//   public float jumpSpeed;
//   public bool isGrouded;
//   public bool isCrouching;
//   public Collider2D GroundCheck;
//   // camera is maincamera;

//   private void Awake() 
//   {
//       Debug.Log("Player controller awake");      
//   }
//   private void Update() 
//   {
//       float speed = Input.GetAxisRaw("Horizontal");
//       animator.SetFloat("Speed", Mathf.Abs(speed));
//       if(isCrouching == true)
//       {
//           speed = 0;
//       }
//       tranform.localPosition += Vector3.right * speed * moveSpeed * Time.deltaTime;

//       if(speed < 0)
//       {
//           tranform.rotation = Quaternion.Euler(tranform.rotation.x, 180, transform.rotation.z);
//       }
//       else if(speed > 0)
//       {
//           tranform.rotation = Quaternion.Euler(tranform.rotation.x, 0, transform.rotation.z);
//       }

//       //jump function
//       if(Input.GetKeyDown(KeyCode.W) && isGrouded)
//       {
//           animator.SetTrigger("Jump");
//           rb2D.velocity = new vector2(rb2D.velocity.x, jumpspeed);
//       }
//       //crouch fuction
//       if(Input.GetKeyDown(KeyCode.S))
//       {
//           animator.SetBool("Crouch",true);
//           isCrouching = true;
//       }
//       else if(Input.GetKeyUp(KeyCode.S))
//       {
//           animator.SetBool("Crouch",false);
//           isCrouching = false;
//       }
//   }
//   void OnCollisionEnter(Collision other)
//     {
//       if(other.gameobject.tag == "Ground")
//       {
//           isGrouded = true;
//       }   
//     }  
//   void OnCollisionExit(Collision other)
//     {
//       if(other.gameobject.tag == "Ground")
//       {
//           isGrouded = false;
//       }   
//     }  
// } 