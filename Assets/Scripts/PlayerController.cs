using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb; 
    public float jump = 3f;
    public float speed = 1f;
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
        Flipx(horispeed);
        Move(horispeed);
        Jumpy();                   
        Crouchy();                       
                                 
    }

    void Move(float horispeed)
    {
        Vector2 newposition = transform.position;
        newposition.x += horispeed*speed*Time.deltaTime;
        transform.position = newposition;
    }
    void Flipx(float horispeed)
    {
        if (horispeed < 0)
        {
            spriteRenderer.flipX = true;

        }
        if (horispeed > 0)
        {
            spriteRenderer.flipX = false;

        }
        animator.SetFloat("Speed", horispeed);
    }
    void Jumpy()
    {
        if ( Input.GetKeyDown(KeyCode.Space)  && isGrounded == true){
           
            animator.SetBool("IsJumping", true);           
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
        if (Input.GetKeyDown(KeyCode.LeftControl) && iscrouch==false)
        {
            iscrouch = true;
            
                animator.SetBool("IsCrouching", true);
            
           
                    
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
