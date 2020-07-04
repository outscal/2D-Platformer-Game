using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ellen_Movement : MonoBehaviour
{
    public Animator anime;
    private SpriteRenderer mySpriteRenderer;
    Collision2D collision;
    BoxCollider2D bc;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(9))
        {
            anime.SetBool("OnGround", true);
        }
        else
        {
            anime.SetBool("OnGround", false);
        }
    }

    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Horz_Movement();
        Jump();
        Crouch();
    }

    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anime.SetBool("isCrouch", !anime.GetBool("isCrouch"));
            if (anime.GetBool("isCrouch") == true)
            {
                anime.Play("Ellen_Crouch", -1, 0f);
                bc.size = new Vector2(0.89f, 1.32f);
                bc.offset = new Vector2(-0.12f, 0.57f);
            }
            if (anime.GetBool("isCrouch") == false)
            {
                bc.size = new Vector2(0.59f, 2.07f);
                bc.offset = new Vector2(0.021f, 0.95f);
            }
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*anime.Play("Ellen_Jump", -1, 0f);*/
            anime.SetBool("Jump1", true);
            /*anime.SetBool("First_Jump", true);*/
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anime.SetBool("Second_Jump", true);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                anime.SetBool("Second_Jump", false);
            }
        }
        /*else if (Input.GetKeyUp(KeyCode.Space))
        {
            anime.SetBool("J", false);
        }*/
    }

    public void Horz_Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        anime.SetFloat("Speed", Mathf.Abs(horizontal));

        if (horizontal < 0)
        {
            mySpriteRenderer.flipX = true;
        }
        else if (horizontal > 0)
        {
            mySpriteRenderer.flipX = false;
        }
    }

}
