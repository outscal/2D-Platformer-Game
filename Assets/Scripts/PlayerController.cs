using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;
    private BoxCollider2D boxCol;
    private void Awake()
    {
        Debug.Log("Player controller awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        boxCol = this.GetComponent<BoxCollider2D>();
    }
    
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Debug.Log("Collision: " + collision.gameObject.name);
    // }

    private void Update()
    {
        //for running animation
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Jump");

        MoveCharacter(horizontalInput, verticalInput);
        PlayMovementAnimation(horizontalInput, verticalInput);
        if(Input.GetKey(KeyCode.LeftControl))
        {
            Crouch(true);
        }
        else
        {
            Crouch(false);
        }
    }

    private void MoveCharacter(float horizontalInput, float verticalInput)
    {
        //move character horizontally 
        Vector3 position = transform.position;
        position.x += horizontalInput * speed * Time.deltaTime;
        transform.position = position;

        //move chararcter vertically
        if (verticalInput > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }

    private void PlayMovementAnimation(float horizontalInput, float verticalInput)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        Vector3 scale = transform.localScale;
        if(horizontalInput < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if(horizontalInput > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Jump
        if(verticalInput > 0)
        {
            animator.SetBool("Jump", true); 
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void Crouch(bool crouch)
    {
        if (crouch == true)
        {
            animator.SetBool("Crouch", crouch);
            boxCol.size = new Vector3(0.521844f, 1.242456f);
            boxCol.offset = new Vector3(-0.004164129f, 0.566561f);
        }
        else
        {
            animator.SetBool("Crouch", false);
            boxCol.size = new Vector3(0.521844f, 2.026481f);
            boxCol.offset = new Vector3(-0.004164129f, 0.9585738f);
        }
    }

   
}