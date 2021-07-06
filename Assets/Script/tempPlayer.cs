using UnityEngine;

public class TempPlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Animator animator;
    private BoxCollider2D boxcollider2d;

    public float crouchOffSetx, crouchOffSety;
    public float crouchSizex, crouchSizey;
    public float offsetx, offsety;
    public float sizex, sizey;
    public float speed;
    public float jumpForce;
    private bool isGrounded;
    private int jumpcount=0;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        boxcollider2d = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("platformtag"))
        {
            isGrounded = true;
            Debug.Log("On Ground !! Can Jump");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("platformtag"))
        {
            isGrounded = false;
            Debug.Log("On Air !! Jump stopped");
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        PlayerAnimation(horizontal, vertical);
        PlayerMovement(horizontal, vertical);
    }

    private void PlayerMovement(float horizontal, float vertical)
    {
        //horizontal movement
        Vector2 currentPosition = transform.position;
        currentPosition.x += speed * horizontal *Time.deltaTime;
        transform.position = currentPosition;

        //vertical movement
        if ((vertical > 0) && (isGrounded==true))
        {
            rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            Debug.Log("jump on");
            isGrounded = false;
        }
    }

    private void PlayerAnimation(float horizontal, float vertical)
    {
        //horizontal animation
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector2 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;



        //vertical animation
        if ((vertical > 0) && (rb2d.velocity.y>0))
        {
            if(jumpcount == 0 && isGrounded == false) 
            {
                animator.SetBool("IsJump", true);
                jumpcount = 1;
            }    
            animator.SetBool("JumpFall", false);
        }
        else
        { 
            animator.SetBool("JumpFall", true);
            animator.SetBool("IsJump", false);

            if(isGrounded==true)
            {
                jumpcount = 0;
            }
        }

        if ((rb2d.velocity.y == 0) && (isGrounded==true))
        {
            animator.SetBool("JumpFall", false);
        }

        if (isGrounded == false)
        {
            animator.SetBool("JumpFall", true);
        }


        //crouch animation
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("IsCrouch", true);
            boxcollider2d.offset = new Vector2(crouchOffSetx, crouchOffSety);
            boxcollider2d.size = new Vector2(crouchSizex, crouchSizey);
        }
        else
        {
            animator.SetBool("IsCrouch", false);
            boxcollider2d.offset = new Vector2(offsetx, offsety);
            boxcollider2d.size = new Vector2(sizex, sizey);
        }
    }
}