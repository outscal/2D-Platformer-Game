using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour

{

public ScoreController scoreController;
public Animator animator;
public float speed;
public float jump;
private Rigidbody2D rb2d;
private bool isGrounded;


  private void Awake() 
  {
    Debug.Log("Player controller is Awake");
    rb2d= gameObject.GetComponent<Rigidbody2D>();
    animator = gameObject.GetComponent<Animator>();
 }


 // private void OnCollisionEnter2D(Collision2D collision) 
 // {
 //  Debug.Log("Collision: " + collision.gameObject.name);
 //  }

    private void Update()
   {

    float horizontal= Input.GetAxisRaw("Horizontal");
    float vertical= Input.GetAxisRaw("Jump");
    MoveCharacter(horizontal, vertical);
    PlayerMovementAnimation(horizontal, vertical);

   }


//MOVEMENT
   private void MoveCharacter(float horizontal, float vertical)
{

// Move Chracter Horizontally
Vector3 position = transform.position;
position.x += horizontal * speed * Time.deltaTime;
transform.position = position;


// Move Chracter Vertically
if (vertical > 0)
{
 animator.SetTrigger("Jump");
 rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse );
 }
}
 
private void OnCollisionStay2D(Collision2D other)
    {
        if(other.transform.tag == "Platform")
        {
            isGrounded = true;
        } 
    }

    private void OnCollision(Collision2D other)
    {
        if (other.transform.tag == "Platform")
        {
            isGrounded = false;
        }
 
    }


//ANIMATION
private void PlayerMovementAnimation(float horizontal, float vertical)
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
if  (vertical > 0)
{
 animator.SetBool("Jump",  true);
}
else
{
 animator.SetBool("Jump",  false);
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

//Death
private void OnTriggerEnter2D(Collider2D other)
 {
    if (other.gameObject.CompareTag("Death"))
    {
        animator.SetTrigger("Death");
    }
}

//Restart After Death
public void Restartlevel()
{
  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
  Debug.Log("Level restarted");
}

// Key Pickup
    public void PickUpKey()
    {
        Debug.Log("Player pick up the key");
        scoreController.IncreaseScore(10);
    }

    public void KillPlayer()
    {
        Debug.Log("Player killed by enemy");
        Restartlevel();
    }
}

