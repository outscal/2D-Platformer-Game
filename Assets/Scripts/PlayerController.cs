using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb; 
    public float jump = 5f;
    
    private bool iscrouch=false;
    private bool isGrounded = true;
   
    
   
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();         
        animator.SetBool("IsCrouching", false);
        animator.SetBool("IsJumping", false);       
    }

    // Update is called once per frame
    void Update()
    {
        float horispeed = Input.GetAxisRaw("Horizontal");
       
       
        if (horispeed < 0)
        {
            spriteRenderer.flipX = true;           
                     
        }
        if(horispeed > 0)
        {
            spriteRenderer.flipX = false;           
                    
        } 
        animator.SetFloat("Speed", horispeed);
        
            Jumpy();                   
            Crouchy();                       
                                 
    }
    void Jumpy()
    {
        if ( Input.GetKeyDown(KeyCode.Space)  && isGrounded == true){
           
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsCrouching", false);
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGrounded = false;
            
        }
        else 
        {
            animator.SetBool("IsJumping", false);
            Standing();
        }
    }

    void Crouchy()
    {
        if (Input.GetKey(KeyCode.LeftControl) && iscrouch==false)
        {
            iscrouch = true;
            animator.SetBool("IsCrouching", true);
            animator.SetBool("IsJumping", false);          
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) && iscrouch==true)
        {
            iscrouch = false;
            animator.SetBool("IsCrouching", false);
             Standing();
        }
        
             
    }

    void Standing()
    {
        animator.SetBool("IsCrouching", false);
        animator.SetBool("IsJumping", false);            
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
           
        }
    }



}
