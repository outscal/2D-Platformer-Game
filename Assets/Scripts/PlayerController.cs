using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Implementation of Player Animations:Idle,Run,Crouch,Jump.
/// Player Movements: Run, Jump 
/// </summary>

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ScoreController scoreController;
    private Rigidbody2D rb2d;
    private Animator animator;
    private BoxCollider2D boxcollider2d;

    [SerializeField] private float crouchOffSetx, crouchOffSety;
    [SerializeField] private float crouchSizex, crouchSizey;
    [SerializeField] private float offsetx, offsety;
    [SerializeField] private float sizex, sizey;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private bool isGrounded;
    private int jumpcount=0;
    private float horizontal;
    private float vertical;
    private int score = 10;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        boxcollider2d = gameObject.GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("platformtag"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Death"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("platformtag"))
        {
            isGrounded = false;
        }
    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        PlayerAnimation(horizontal, vertical);
        PlayerHorizontalMovement(horizontal);
    }

    private void PlayerHorizontalMovement(float horizontal)
    {
        //horizontal
        Vector2 currentPosition = transform.position;
        currentPosition.x += speed * horizontal * Time.deltaTime;
        transform.position = currentPosition;
    }

    private void FixedUpdate()
    {
        PlayerVerticalMovement(vertical);
    }

    private void PlayerVerticalMovement(float vertical)
    {
        //vertical movement
        if ((vertical > 0) && (isGrounded == true))
        {
            rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void PlayerAnimation(float horizontal, float vertical)
    {
        HorizontalAnimation(horizontal);
        VerticalAnimation(vertical);
        CrouchAnimation();
    }

    private void CrouchAnimation()
    {
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

    private void VerticalAnimation(float vertical)
    {
        //vertical animation
        if ((vertical > 0) && (rb2d.velocity.y > 0) && (isGrounded == false))
        {
            if (jumpcount == 0)
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

            if (isGrounded == true)
            {
                jumpcount = 0;
            }
        }

        if ((rb2d.velocity.y == 0) && (isGrounded == true))
        {
            animator.SetBool("JumpFall", false);
        }

        if (isGrounded == false)
        {
            animator.SetBool("JumpFall", true);
        }
    }

    private void HorizontalAnimation(float horizontal)
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
    }


    public void CollectibleKey()
    {
        scoreController.IncrementScore(score);
    }
}
