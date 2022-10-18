using UnityEngine;


public class Player_Controller : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private Animator _animator;
    public GameObject player;
    public ScoreController _scoreController;
    public GameOverController gameOverController;
    
    
    [SerializeField]
    private float _playerSpeed = 5.5f;

    //Jump
    [SerializeField]
    private float _jumpSpeed;
    public Transform GroundCheck;
    public LayerMask groundLayer;
    private bool doubleJump;
    
    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
       _animator = gameObject.GetComponent<Animator>();
    }
  
    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        MoveCharecter(horizontal);
        Crouch();
        HorizontalAnimation(horizontal);

        JumpAnimation();
    }

    private void JumpAnimation()
    {
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                // _animator.SetTrigger("Jump");
                rb2d.velocity = new Vector2(rb2d.velocity.x, _jumpSpeed);
                doubleJump = !doubleJump;
            }
        }
        if (Input.GetButtonUp("Jump") && rb2d.velocity.y > 0f)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, groundLayer);
    }
    void MoveCharecter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * _playerSpeed * Time.deltaTime;
        transform.position = position;
    }

    public void HorizontalAnimation(float horizontal)
        {
            _animator.SetFloat("speed", Mathf.Abs(horizontal));
        
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


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("MovingPlatform"))
        {
            player.transform.parent = other.gameObject.transform;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
           
        }
    }
    public void KillPlayer()
    {
        gameOverController.PlayerDied();
        this.enabled = false;
    }
    void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _animator.SetBool("crouch", true);
        }
        else
        {
            _animator.SetBool("crouch", false);
        }
    }
    public void PickUpKeys()
    {
        _scoreController.AddScore(10);
    }
  
}
