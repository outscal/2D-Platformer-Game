using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator _animator;

    [SerializeField]
    private float _playerSpeed = 5.5f;
    [SerializeField]
    private float _jump;

    public bool isGrounded;
    public float _groundRadius;
    public LayerMask whatIsGround;
    public Transform groundPoint;
    


    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxisRaw("Jump");
        
        MoveCharecter(horizontal);
        MovementAnimation(horizontal, jump);
        
        Crouch();


        if (Input.GetKeyDown(KeyCode.Space))
        {
          
         
       
        }
    }

    void PlayerStatus()
    {
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, _groundRadius, whatIsGround);
    }
    void MoveCharecter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * _playerSpeed * Time.deltaTime;
        transform.position = position;
    }


    private void MovementAnimation(float horizontal, float vertical)
    {
        HorizontalAnimation(horizontal);
      
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
}
