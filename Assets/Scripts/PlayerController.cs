using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public float Speed;
    public float jumpforce;
    public bool OnGround;
    //public float vertical;
    private bool isCrouching;
    private Rigidbody2D rb2d;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            OnGround = true;     
    }
    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Ground")
            OnGround = false;
    }
    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    /*void Start()
    {

    }*/

    // Update is called once per frame
     void Update()
     {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

       // MoveCharacter(horizontal, vertical);
        PlayerMovementAnimation(horizontal, vertical);
        PlayerMovement(horizontal);
        Jump(vertical);
     }

   /* private void MoveCharacter(float horizontal, float vertical)
    {
       
            PlayerMovement(horizontal);

        *//*if (vertical > 0 && OnGround)
            Jump(vertical);*//*

        //jump method 2
        *//*else if (vertical > 0 && Mathf.Abs(rb2d.velocity.y) < 0.001f)
        {
            rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
        }*//*

    }*/

    
    private void PlayerMovement(float horizontal)
    {
        if (!isCrouching)
        {
            Vector3 position = transform.position;
            position.x = position.x + horizontal * Speed * Time.deltaTime;
            transform.position = position;
        }
    }

    private void Jump(float vertical)
    {
        if (vertical > 0 && OnGround)
            rb2d.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Force);
    }

    private void PlayerMovementAnimation(float horizontal, float vertical)

    {
        RunandFlip(horizontal);
        JumpandCrouch(vertical);
    }

    private void JumpandCrouch(float vertical)
    {
        if (vertical > 0)
            animator.SetBool("jump", true);
        else if
            (OnGround && vertical < 1) animator.SetBool("jump", false);

        if (vertical < 0)
        {
            isCrouching = true;
            animator.SetBool("crouch", true);
        }
        else
        {
            isCrouching = false;
            animator.SetBool("crouch", false);
        }
    }

    private void RunandFlip(float horizontal)
    {
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;

        if (horizontal < 0 && scale.x > 0)
            scale.x = -1f * Mathf.Abs(scale.x);

        else if (horizontal > 0 && scale.x < 0)
            scale.x = Mathf.Abs(scale.x);

        transform.localScale = scale;
    }
   


}
