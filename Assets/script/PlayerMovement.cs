using System.Collections;
using System.Collections.Generic;

using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;
=======
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{


    public Animator animator;
    public float speed;
    public float jump;
    public BoxCollider2D boxCollider2D;
    private Rigidbody2D rb2d;

    private Vector2 offsetx;
    private Vector2 offsety;


    private void Awake()
    {
        Debug.Log("Player controller awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
      private void Start( )
    {
        //Fetching initial collider properties
        offsetx = boxCollider2D.size;
        offsety = boxCollider2D.offset;
    }


    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
         float vertical = Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal , vertical);
        PlayMovementAnimation(horizontal , vertical);


    }

    private void MoveCharacter(float horizontal ,float vertical)
    {
        Vector3 positon = transform.position;
        positon.x += horizontal * speed * Time.deltaTime;
        transform.position = positon;

        if (vertical>0)
        {
            rb2d.AddForce(new Vector2(0f , jump), ForceMode2D.Force);
        }

    }
    private void PlayMovementAnimation(float horizontal, float vertical)
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
            animator.SetBool("IsJump", true);
        }
        else
        {
            animator.SetBool("IsJump", false);
        }
        if (Input.GetKey(KeyCode.S)) 
        {
            Crouch(true);
        }
        else
        {
            Crouch(false);
        }

    }
        public void Crouch(bool crouch)
        {
            if (crouch == true)
            {
                float offX = -0.0978f;     //Offset X
                float offY = 0.5947f;      //Offset Y

                float sizeX = 0.6988f;     //Size X
                float sizeY = 1.3398f;     //Size Y

                boxCollider2D.size = new Vector2(sizeX, sizeY);   //Setting the size of collider
                boxCollider2D.offset = new Vector2(offX, offY);   //Setting the offset of collider
            }

            else
            {
                //Reset collider to initial values
                boxCollider2D.size = offsetx; ;
                boxCollider2D.offset = offsety;
                
            }

            //Play Crouch animation
            animator.SetBool("Crouch", crouch);
        }
    }















=======
    private float horizontal;
    private float speed = 7f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundlayer;



    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        flip();

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void flip()
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}

