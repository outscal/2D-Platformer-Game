using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public float speed;
    public float jump;
    public float crouch;

    private Rigidbody2D rb2d;
    private void Awake()
    {
        Debug.Log("Player Controller awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

   // private void OnCollisionEnter2D(Collision2D collision)
   // {
   //     Debug.Log("Collision: " + collision.gameObject.name);
   // }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        float crouch = Input.GetAxisRaw("Crouch"); //made a different instruction for this
        MoveCharacter(horizontal, vertical, crouch);
        PlayMovementAnimation(horizontal, vertical, crouch);
    }

    private void MoveCharacter(float horizontal, float vertical, float crouch)
    {
        //move character horizontally
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //move characer vertically
        if(vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
        if(crouch > 0)
        {
            rb2d.AddForce(new Vector2(0f, crouch), ForceMode2D.Force);
        }

    }

    private void PlayMovementAnimation(float horizontal, float vertical, float crouch)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
           
        }
        else
        {
            animator.SetBool("Jump", false);
          
        }

        if (crouch >0)
        {
            animator.SetBool("Crouch", true);

        }
        else
        {
            animator.SetBool("Crouch", false);

        }

    }
}

