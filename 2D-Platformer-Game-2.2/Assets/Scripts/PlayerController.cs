using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  public KeyScoreController keyScoreController;
  public GameOverController gameOverController;
  private PlayerHealth health;
  public Animator animator;
  public Rigidbody2D rb2D;
  public Collider2D groundCheck;
  public float moveSpeed;
  public float jumpSpeed;
  public bool isGrounded;
  public bool isCrouching;
  
  private Vector3 respawnPoint;
  public GameObject fallDetector;
  
  private void Awake() 
  {
    Debug.Log("Player controller awake");
    health = GetComponent<PlayerHealth>();
  }

  void start()
  {
    respawnPoint = transform.position;
  }

  public void KillPlayer()
  {
    Debug.Log("Player died");
    //Destroy(gameObject);
    //ReloadLevel();
  }

  // private void ReloadLevel ()
  // {
  //   Debug.Log("Reloading Scene 0 ........");
  //   SceneManager.LoadScene(0);
  // }

  public void PickUpKey()
  {
    Debug.Log("Player picked up the key");
    keyScoreController.IncreaseScore(1);
  }

  public void PlayerDamaged (float enemyDamage) 
  {
    health.UpdateHealth(-enemyDamage);
    if(PlayerHealth.gameOver)
    {
      // animator.SetTrigger("Death");
      gameOverController.PlayerDied();
      return;
    }
    rb2D.velocity += Vector2.up * 10;
    animator.SetTrigger("Hurting");
  }
  
  private void Update()
  {

    if(PlayerHealth.gameOver)
    {
      //death animation
      animator.SetTrigger("Death");

      //disable script
      this.enabled = false;
    }
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

    fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    
  }

  void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag == "FallDetector")
    {
      transform.position = respawnPoint;
    }
  }

  void OnCollisionEnter2D(Collision2D other) 
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