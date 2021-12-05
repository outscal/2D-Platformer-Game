using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public float speed;
    public float jump;

    public bool isGrounded = false;

    private Rigidbody2D rBody;
    private BoxCollider2D boxCollider2D; 

    private void Awake()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();
        gameObject.GetComponent<SpriteRenderer>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    } 

    // Update is called once per frame
    private void Update()
    {
        //horizontal movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        PlayerMovementAnimation(horizontal, vertical);
        MoveCharacter(horizontal, vertical);

        //vertical player movement
        //if (vertical > 0 && isGrounded)
        //{
        //    rBody.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        //}

    }

    private void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Jump");
        //vertical player movement
        if (vertical > 0 && IsGrounded())
        {
            //rBody.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            rBody.velocity = Vector3.up * jump;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        //horizontal player movement
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

    }

    private void PlayerMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        //Debug.Log("Speed is" + speed);
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * (Mathf.Abs(scale.x));
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;

        //Jump code
        //float vertical = Input.GetAxisRaw("Jump");
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);

        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private bool IsGrounded()
    {
        float extraHeightText = 0.01f;
        RaycastHit2D raycasthit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightText);
        Color rayColor;
        if (raycasthit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extents.y + extraHeightText));
        return raycasthit.collider != null;
    }
}
