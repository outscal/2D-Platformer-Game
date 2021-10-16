using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    public float speed;
    public float jump;
    public bool isGrounded; 

    private Rigidbody2D rb; 

    private Vector2 standingColliderOffset = new Vector2(0f, 0.98f);
    private Vector2 standingColliderSize = new Vector2(0.45f, 2.05f);
    private Vector2 crouchingColliderOffset = new Vector2(-0.15f, 0.6f);
    private Vector2 crouchingColliderSize = new Vector2(0.75f, 1.3f);


    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();     
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        MoveCharacter(horizontal, vertical); 
        PlayerMovementAnimation(horizontal, vertical);
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        //move character horizontally
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //move character vertically
        if(vertical > 0 && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Force); 
        }

    }

    private void PlayerMovementAnimation(float horizontal, float vertical)
    {

        //Move horizontally to Walk/Run
        playerAnimator.SetFloat("speed", Mathf.Abs(horizontal));

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
        

        //Jump
        if (vertical > 0)
        {
            playerAnimator.SetBool("jump", true);
        }
        else
        {
            playerAnimator.SetBool("jump", false);
        }

        //Crouch
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            playerAnimator.SetBool("crouch", true);

            GetComponent<BoxCollider2D>().offset = crouchingColliderOffset;
            GetComponent<BoxCollider2D>().size = crouchingColliderSize;
        }
        else
        {
            playerAnimator.SetBool("crouch", false);

            GetComponent<BoxCollider2D>().offset = standingColliderOffset;
            GetComponent<BoxCollider2D>().size = standingColliderSize;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            isGrounded = false;
        }
    }

}
