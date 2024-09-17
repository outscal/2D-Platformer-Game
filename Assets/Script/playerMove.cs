using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    //All data members
    [SerializeField] float speed;
    [SerializeField] float Jump_force;
    [SerializeField] float Jump_distance;
    [SerializeField] float walk_speed;
    private bool IsCrouching;
    private float Xmove_run;
    private float Xmove_walk;
    private float Ymove;
    private bool isAttacking;
    private bool isJumping;
    private Rigidbody2D rb;
    private SpriteRenderer renderer;
    private Animator anim;
    [SerializeField]BoxCollider2D collider2D;
    [SerializeField] LayerMask ground;

    //crouching.................................................
   


    //Array of animation states
    private enum movementState {idle, walk, run, jump, attack_Ground, attack_Air}

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        collider2D = GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        ////For player walk movement...........................................................................................
        // if(Input.GetKey(KeyCode.A)&&Input.GetKey(KeyCode.D) && IsGrounded())
        //{
        //    Xmove_walk = Input.GetAxisRaw("Horizontal");
        //    rb.velocity = new Vector2(Xmove_walk * walk_speed, rb.velocity.y);
        //}
         //For sprint/Run........................................................................................................
        if(Input.GetKey(KeyCode.LeftShift) && IsGrounded() && !IsCrouching && !isJumping)
        {
            Xmove_run = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(Xmove_run * speed, rb.velocity.y);
        }

        //For jump..............................................................................................................
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            isJumping = true;
            rb.velocity = new Vector2(0, Jump_force);
           
            isJumping = false;
            
        }
      
        //Crouch..................................................................................................................
      
        if (Input.GetKeyDown(KeyCode.C) && IsGrounded())
        {
            IsCrouching = true;
            anim.SetBool("Crouch", true);
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            IsCrouching = false;
            anim.SetBool("Crouch", false);
        }
    }

    private void FixedUpdate()
    {
        
        movementState state;


        ////Walk animation..................................................................................................
        //if (Xmove_walk>0f)
        //{
        //    state = movementState.walk;
        //    renderer.flipX = false;
        //}
        //else if(Xmove_walk<0f)
        //{
        //    state = movementState.walk;
        //    renderer.flipX = true;
        //}
        //else { state = movementState.idle;}

        //Run animation....................................................................................................
        if(Xmove_run>0f)
        {
            state = movementState.run;
            renderer.flipX = false;
        }
        else if(Xmove_run<0f)
        {
            state = movementState.run;
            renderer.flipX = true;
        }
        else { state = movementState.idle; }

        //Jump...........................................................................................................
        if(rb.velocity.y>.1f)
        {
            anim.SetTrigger("Jump");
            state = movementState.jump;
        }

    
     
        anim.SetInteger("state", (int)state);
    }
   
    private bool IsGrounded()
    {
       return Physics2D.BoxCast(collider2D.bounds.center, collider2D.bounds.size, 0f, Vector2.down, .1f, ground);
    }
    
}
