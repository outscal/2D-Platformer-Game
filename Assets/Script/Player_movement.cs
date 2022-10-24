using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpforce;
    [SerializeField] private BoxCollider2D coll;
    private Animator anim;
    [SerializeField] private SpriteRenderer sprite;
    private float Xmove;
    [SerializeField] private LayerMask jumpebleGround;
    [SerializeField] private AudioSource Jumpsound;


    private enum movementstate { idle, walk, run, jump }



    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    private void Update()
    {
        //for player movement
        Xmove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(Xmove * 7f, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && isGrounded())
        {
           
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }



        updateanimationupdate();


    }

    private void updateanimationupdate()
    {
        movementstate state;
        //player animations
        if (Xmove > 0f)
        {
            anim.SetFloat("speed", 4f);
            state = movementstate.walk;
            sprite.flipX = false;
        }
        else if (Xmove < 0f)
        {
            anim.SetFloat("speed", 4f);
            state = movementstate.walk;
            sprite.flipX = true;
        }

        if (Input.GetKeyDown("shift") || Xmove>0f)
        {
            speed = 6f;
            state = movementstate.run;
            anim.SetFloat("speed", 6f);
        }
        else if (Input.GetKeyDown("shift") || Xmove < 0f)
        {
            speed = 6f;
            state = movementstate.run;
            anim.SetFloat("speed", 6f);
        }
        else
        {
            state = movementstate.idle;

        }
        if (rb.velocity.y > .1f)
        {
            state = movementstate.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = movementstate.idle;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpebleGround);
    }

}
