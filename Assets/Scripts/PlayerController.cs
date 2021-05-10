using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Cached references
    BoxCollider2D boxCollider;
    Rigidbody2D rigidBody2D;
    public Animator animator;
    bool isGrounded;
    private void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        rigidBody2D = GetComponent<Rigidbody2D>();

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        Debug.Log("Collision : " + collision.gameObject.name + " is grounded =  " + isGrounded);
        if (isGrounded)
        {
            rigidBody2D.gravityScale = 0;
        }
    }

    private void Update()
    {
        float hspeed = Input.GetAxisRaw("Horizontal");
        float vSpeed = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(hspeed));
        Vector3 scale = transform.localScale;
        boxCollider.offset = new Vector2(0.024f, 1.01f);
        boxCollider.size = new Vector2(0.62f, 2.07f);

        if (vSpeed == 1)
        {
            animator.SetBool("Jump", true);
            boxCollider.offset = new Vector2(0.15f, 1.75f);
            boxCollider.size = new Vector2(0.86f, 1.45f);
        }
        else if (vSpeed < 1)
        {
            animator.SetBool("Jump", false);
            
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", true);
            boxCollider.offset =  new Vector2(-0.17f,0.60f);
            boxCollider.size =  new Vector2(0.88f, 1.38f);
        }
        else if(!Input.GetKey(KeyCode.LeftControl))
        {
            /*animator.SetBool("Jump", false);*/
            animator.SetBool("isCrouch", false);
           
        }
        if (hspeed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (hspeed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
}
