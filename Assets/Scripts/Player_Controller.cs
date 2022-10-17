
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class Player_Controller : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private Animator _animator;
    public GameObject player;
    public ScoreController _scoreController;
    
    

    [SerializeField]
    private float _playerSpeed = 5.5f;

    //Jump
    [SerializeField]
    private float _jumpSpeed;
    
    
   
  

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

        if (Input.GetButtonDown("Jump"))
        {
          //  _animator.SetBool("Jump", true);
            rb2d.velocity = new Vector2(rb2d.velocity.x, _jumpSpeed);
        }
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
           // player.transform.parent = other.gameObject.transform;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {

        }
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
