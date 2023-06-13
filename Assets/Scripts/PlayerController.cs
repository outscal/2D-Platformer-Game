using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator Animator;
    public Rigidbody2D rigidbody2d;
    public float velocity;
    public float jump;
    public bool isGrounded;
    public int collected = 0;

    private void Start () 
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 && !isGrounded)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 && isGrounded)
        {
            isGrounded = false;
        }
    }

    private void Update ()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Animations(horizontal);
        Movement(horizontal, jump);
    }

    private void Movement (float horizontal, float jump) 
    {
        Vector3 position = transform.position;
        position.x += horizontal * velocity * Time.deltaTime;
        transform.position = position;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody2d.AddForce(new Vector2(rigidbody2d.velocity.y, jump));
        }
    }

    private void Animations (float horizontal) 
    {
        Animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Animator.SetTrigger("Jumped");
        }

        transform.localScale = scale;

        if (Input.GetKeyDown("left ctrl") || Input.GetKeyDown("right ctrl"))
        {
            Animator.SetTrigger("someTrigger");
            Animator.ResetTrigger("otherTrigger");
            Animator.SetBool("Crouched", true);
        }
        else if (Input.GetKeyUp("left ctrl") || Input.GetKeyUp("right ctrl"))
        {
            Animator.SetTrigger("otherTrigger");
            Animator.ResetTrigger("someTrigger");
            Animator.SetBool("Crouched", false);
        }
    }

    public void Pickup()
    {
        collected += 1;
    }
}
