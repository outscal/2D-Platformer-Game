using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Animator animator;
    
    public float jump;
    private bool _isGrounded;
    [SerializeField]
    private float _playerSpeed;


    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        MoveCharecter(horizontal);
        MovementAnimation(horizontal);
        MoveVertically(vertical);
        Crouch();
    }
    void MoveCharecter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * _playerSpeed * Time.deltaTime;
        transform.position = position;
    }

    private void MoveVertically(float vertical)
    {
       
        if (vertical > 0 && _isGrounded)
        {
            animator.SetBool("jump", true);
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag == "platform")
        {
            _isGrounded = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.transform.tag == "platform")
        {
            _isGrounded = false;
        }
    }
    private void MovementAnimation(float horizontal)
    {
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        
        //move and flip
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
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", true);

        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", false);
        }
    }
}
