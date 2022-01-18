using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public Animator animator;
  public Rigidbody2D rb2D;
  public float moveSpeed;
  public float jumpSpeed;
  public bool isGrounded;
  public bool isCrouching;
  
  private void Awake() 
  {
    Debug.Log("Player controller awake");  
  }
  
  private void Update()
  {
    float speed = Input.GetAxisRaw("Horizontal");
    animator.SetFloat("Speed", Mathf.Abs(speed));
    if(isCrouching == true)
    {
      speed = 0;
    }
    // rb2D.velocity = new Vector2(speed * moveSpeed,rb2D.velocity.y);
    transform.localPosition += Vector3.right * speed * moveSpeed * Time.deltaTime;
    
    if(speed < 0)
    {
      transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
    }
    else if(speed > 0)
    {
      transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
    }

    // Jump
    if(Input.GetKeyDown(KeyCode.W) && isGrounded)
    {
      animator.SetTrigger("Jump");
      rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
    }
    // Crouch
    if(Input.GetKeyDown(KeyCode.S))
    {
      animator.SetBool("Crouch", true);
      isCrouching = true;
    }
    else if (Input.GetKeyUp(KeyCode.S))
    {
      animator.SetBool("Crouch", false);
      isCrouching = false;
    }
    
  }

  void OnCollisionEnter2D(Collision2D other) 
  {
    if (other.gameObject.tag == "Ground")
    {
      isGrounded = true;
    }
  }
  void OnCollisionExit2D(Collision2D other) 
  {
    if (other.gameObject.tag == "Ground")
    {
      isGrounded = false;
    }
  }
  
}