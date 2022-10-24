using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Crouch : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator anim;
    public float jumpForce;
    [SerializeField] BoxCollider2D collider2D;
    [SerializeField] LayerMask ground;
    private bool isJumping;
    [SerializeField] float jumpingPower;
  
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    //Array of animation states
    private enum movementState { Blend_tree, jump, crouch, attack_Ground, attack_Air }


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        //....................................................*JUMP*...........................................................
       
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
          
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
            
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            

            jumpBufferCounter = 0f;

            StartCoroutine(JumpCooldown());
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            
            coyoteTimeCounter = 0f;
        }

        //.............................................*CROUCH*..........................................................

        if (Input.GetKeyDown(KeyCode.C) && IsGrounded())
        {
            IsCrouching();
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            IsCrouching();

        }

        //..............................................*ANIMATOR*.......................................................
        movementState state;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump 0");
            state = movementState.jump;
        }
        else { state = movementState.Blend_tree; }

        if (Input.GetKeyDown(KeyCode.C) && IsGrounded())
        {
            anim.SetBool("Crouch", true);
            state = movementState.crouch;
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            anim.SetBool("Crouch", false);
            state = movementState.Blend_tree;

        }


        anim.SetInteger("state", (int)state);



    }

    private void FixedUpdate()
    {
      
    }

  public bool IsCrouching()
    {
        if (rb.velocity.y < 0f)
        {
            return true;
        }
        else { return false; }
    }
    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider2D.bounds.center, collider2D.bounds.size, 0f, Vector2.down, .1f, ground);
    }

}
