using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Animator animator;
    //bool a;
    //int b = 0;

    public float speed = 10f;

    public float jump = 10f;

    private Rigidbody2D rb2d;

    //separate collider for crouch
    private PolygonCollider2D pc2d;
    private BoxCollider2D bc2d;


    void playerMovement(float horizontal, float vertical)
    {   
        //run animation
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        // jump movement
        if (vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump));
        }
    }

    void playerMovementAnimation(float speed,float vertical,bool isCrouch)
    {   
        //run animation
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);

        }
        else if (speed >= 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Jump Animation
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        //croutch
        if (isCrouch)
        {
            animator.SetBool("Crouch", true);
            pc2d.enabled = false;
            bc2d.enabled = true;
        }
        else
        {
            animator.SetBool("Crouch", false);
            pc2d.enabled = true;
            bc2d.enabled = false;
        }
    }


    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        pc2d = gameObject.GetComponent<PolygonCollider2D>();
        bc2d = gameObject.GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        bool isCroutch = Input.GetKey(KeyCode.LeftControl);

        playerMovement(horizontal, vertical);
        playerMovementAnimation(horizontal, vertical,isCroutch);


    }
}

    