using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    [SerializeField]
    private Animator anim;
    private SpriteRenderer _playerSprite;
    private BoxCollider2D player2d;

    private float m_scalex, m_scaley;
    private bool _isCrouching;

    [Header("Jump Info")]

    [SerializeField] private float jumpForce;
    private Rigidbody2D _rb;
    private bool _isGrounded;
    private float _fallLimit = -7f;

    // Start is called before the first frame update
    void Start()
    {
        _isGrounded = true;
        player2d = GetComponent<BoxCollider2D>();

        _playerSprite = GetComponent<SpriteRenderer>();
        if (_playerSprite == null)
        {
            Debug.Log("Player sprite not available");
        }

        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            Debug.LogError("Rigidbody missing");
        }

        m_scalex = 0.8645924f;
        m_scaley = 1.320639f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < _fallLimit)
        {
            Debug.Log("Player Died");
            SceneManager.LoadScene(0);
        }
        else
        {
            Jump();
            MovementAnimation();
        }

        
    }

    void MovementAnimation()
    {


        float horizontalInput = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(horizontalInput));


        float moveX = (horizontalInput * _speed * Time.deltaTime);

        transform.Translate(new Vector2(moveX, 0));


        //for fliping the sprite 
        if (horizontalInput < 0)
        {
            _playerSprite.flipX = true;
        }
        else
        {
            _playerSprite.flipX = false;
        }


        //for crouch animation
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch(true);
            anim.SetBool("isCrouch", true);
        }
        else
        {
            Crouch(false);
            anim.SetBool("isCrouch", false);
        }


    }


    //crouch collider implementation
    void Crouch(bool crouch)
    {
        if (_isCrouching)
        {
            _isCrouching = true;
            player2d.offset = new Vector2(-0.09592718f, 0.6275121f);
            player2d.size = new Vector2(m_scalex, m_scaley);
        }
        else
        {
            _isCrouching = false;
            player2d.offset = new Vector2(-0.009804815f, 1.000709f);
            player2d.size = new Vector2(0.6518943f, 2.068996f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            _isGrounded = true;
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isGrounded = false;
            anim.SetTrigger("Jump");
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
