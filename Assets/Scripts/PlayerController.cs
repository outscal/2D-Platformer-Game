using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public float Speed;
    public float jumpforce;

    public bool OnGround;
    private bool Crouching = false;
    //private bool Jumping = false;
    private Rigidbody2D rb2d;
    private BoxCollider2D playercollider;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            OnGround = true;
            //Debug.Log("triggering collision");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OnGround = false;
        //Debug.Log("triggering exit");

    }
    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        playercollider = gameObject.GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        MoveCharacter(horizontal,vertical);
        PlayerMovementAnimation(horizontal, vertical);

    }

    

    private void MoveCharacter(float horizontal, float vertical)
    {
        if (!Crouching) //if not crouching
        {
            Vector3 position = transform.position;
            position.x = position.x + horizontal * Speed * Time.deltaTime;
            transform.position = position;
        }
        //jump method 2
        /*else if (vertical > 0 && Mathf.Abs(rb2d.velocity.y) < 0.001f)
        {
            rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
        }*/

        // jump method 1
        if (vertical > 0 && OnGround)// && !Crouching)
        {
            rb2d.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Force);
        }

    }
    private void PlayerMovementAnimation(float horizontal, float vertical)

    { 
        // set animator speed value to horizantal in positive to trigger run animation
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        // flip character if running and if character facing opposite way
        
        Vector3 scale = transform.localScale;
        if (horizontal < 0 && scale.x > 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0 && scale.x < 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        // Setting jump and crouch animations

        //jump animation

        if (vertical > 0)
        {
            //Jumping = true;
            animator.SetBool("jump", true);
        }
        else if (vertical == 0 && OnGround)
        {
            //Jumping = false;
            //if (OnGround)
            animator.SetBool("jump", false);
        }
        //crouch animation

        if (vertical < 0)
        {
            Crouching = true;
            animator.SetBool("crouch", true);           
        }
        else
        {
            Crouching = false;
            animator.SetBool("crouch", false);
        }
    }
}
