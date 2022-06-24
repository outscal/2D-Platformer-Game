using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class PlayerController : MonoBehaviour
{
  public Animator animator;
  public Rigidbody2D rb2D;
  public float moveSpeed;
  public float jumpSpeed;
  public bool isGrounded;
  public bool isCrouching;
  public Collider2D groundCheck;
  private PlayerHealth health;

  [SerializeField]private AudioSource jumpSoundEffect;
  [SerializeField]private AudioSource StartSoundEffect;
  
  
  private void Awake() 
  {
   StartSoundEffect.Play();
    Debug.Log("Player controller awake");  
    health = GetComponent<PlayerHealth>();
  }
  public void PlayerDamaged (float enemyDamage) 
  {
    health.UpdateHealth(-enemyDamage);
     
    if(PlayerHealth.gameOver)
    {
       //animator.SetTrigger("Death");
      SceneManager.LoadScene("GameOver");
      return;
      
    }
    rb2D.velocity += Vector2.up * 6;
    animator.SetTrigger("Hurting");
  }

  
  private void Update()
  {
    float speed = Input.GetAxisRaw("Horizontal");
   
    animator.SetFloat("Speed", Mathf.Abs(speed));

    if(isCrouching == true)
    {
      speed = 0;
    }
    
    transform.localPosition += Vector3.right * speed * moveSpeed * Time.deltaTime;
    
    if(speed < 0)
    {
      transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
    }
    else if(speed > 0)
    {
      transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
    }
    if(PlayerHealth.gameOver)
    {
      animator.SetTrigger("death");
      //SceneManager.LoadScene("GameOver");
      //this.enabled = false;
    }
    
   
   
  
    // Jump
    if(Input.GetKeyDown(KeyCode.W) && isGrounded)
    {
      animator.SetTrigger("Jump");
      jumpSoundEffect.Play();
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
  
    

 
  void OnCollisionStay2D(Collision2D other) 
  {
    if (other.gameObject.tag == "Ground")
    {
      if(!groundCheck.IsTouching(other.collider))
      {
        return;
      }
     
      isGrounded = true;
      
    }
  }
  void OnCollisionExit2D(Collision2D other) 
  {
    if (other.gameObject.tag == "Ground")
    {
      if(groundCheck.IsTouching(other.collider))
      {
        return;
      }

      isGrounded = false;
      
    }
     
    
    
  }
  
}
 
 
