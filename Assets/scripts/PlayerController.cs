using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Animator animator;
    public ScoreController scoreController;
    public float jumpForce;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public GameOverController gameOverController;
    private bool isGrounded;
    [SerializeField]
    private float speed;

    private Vector3 respawnPoint;
    public GameObject FallDetector;
    //public static GameObject gameObject1;

    private void Awake()
    {

        rb2d = gameObject.GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }
    public void PickUpKey()
    {
        Debug.Log("Player has picked up the key ");
        ScoreController scoreController = new ScoreController();
        scoreController.IncreaseScore(10);


    }
    public  void KillPlayer()
    {
        //Debug.Log("player has died");
        //Destroy(gameObject);
        gameOverController.Playerdied();
        //gameOverController.ReloadLevel();
        this.enabled = false;
    }
    


    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        MoveCharacter(horizontal, vertical);
        MovementAnimation(horizontal, vertical);
        Jump(vertical);
        Crouch();

        FallDetector.transform.position = new Vector2(transform.position.x, FallDetector.transform.position.y);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
    }

    void MoveCharacter(float horizontal, float vertical)
    {
        // move character horizontaly 
        Vector3 position = transform.position;
        //delata time 1/30 per sec
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    private void MovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("horizontal", Mathf.Abs(horizontal));

        // flip
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
        //jump animaTION
        if (vertical > 0 && isGrounded)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
    //JUMP FUNCTION
    void Jump(float vertical)
    {
        if (Input.GetButtonDown("Jump") && vertical > 0 && isGrounded)
        {
            isGrounded = false;
            
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
        }
    }
    //crouch function 
    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);

        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
        }
    }
}
