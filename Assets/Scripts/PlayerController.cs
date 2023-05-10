using System.IO.Compression;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public float speed;
    public float jump;
    public bool isGrounded;

    private Vector3 restartPoint;

    public GameObject forDeathDetector;

    public GameOverScreen gos;



    private Rigidbody2D rb2d;

    private void  Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
    } 
   
   void /// <summary>
   /// Start is called on the frame when a script is enabled just before
   /// any of the Update methods is called the first time.
   /// </summary>
   Start()
   {
    restartPoint = transform.position;
   }
    
    
   
    

   
    void Update()
    {
        float vertical = Input.GetAxisRaw("Jump");
        float horizontal = Input.GetAxisRaw("Horizontal");
        //Debug.Log("speed= " + horizontal);

        MoveCharacter(horizontal,vertical);
        PlayerMovementAnimation(horizontal,vertical);
       


        if(Input.GetButtonDown("Fire1")){
            GetComponent<Animator>().Play("Player_Crouch");
        }

        forDeathDetector.transform.position = new Vector2(transform.position.x,forDeathDetector.transform.position.y);
        
    }
    
    private void MoveCharacter(float horizontal,float vertical){

        //move horizontally    
        Vector3 position=transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position =  position;

        //move vertically
        if(vertical>0)
        {
            rb2d.AddForce(new Vector2(0f,jump),ForceMode2D.Force);
        }



    }

    private void PlayerMovementAnimation(float horizontal,float vertical){

       
       animator.SetInteger("Speed",(int)horizontal);

        

       Vector3 scale = transform.localScale;
        if  (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }

        else if ( horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
       
        transform.localScale = scale;


        //Vertical Jump
        if(vertical>0)
        {
            animator.SetBool("Jump",true);
        }
        else
        {
            animator.SetBool("Jump",false);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
{
    if(other.transform.tag == "Platform")
    {
        isGrounded = true;
    } 
}

private void OnCollisionExit2D(Collision2D other)
{
    if (other.transform.tag == "Platform")
    {
        isGrounded = false;
    }
}

private void OnTriggerEnter2D(Collider2D other)
{
    if(other.transform.tag == "FallDetector")
    {
     gos.Setup();
    }
}
}
