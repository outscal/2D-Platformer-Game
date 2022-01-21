using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public float Speed;
    public float jumpforce;
    private Rigidbody2D rb2d;
    private BoxCollider2D playercollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colliding with :" + collision.gameObject.name);
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
    { // move character
        Vector3 position = transform.position;
        position.x = position.x + horizontal * Speed * Time.deltaTime;
        transform.position = position;

    
        // jump 
        if (vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Force);
            
        }
        //else rb2d.AddForce(new Vector2(0f, 0f)); //, ForceMode2D.Impulse);
    }
    private void PlayerMovementAnimation(float horizontal, float vertical)
    {    // set animator speed value to horizantal in positive to trigger run animation
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        // flip character if running and character facing opposite way
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
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }
        //crouch animation
        if (vertical < 0)
        {
            animator.SetBool("crouch", true);
            
        }
        else
        {
            animator.SetBool("crouch", false);
        }
    }
}
