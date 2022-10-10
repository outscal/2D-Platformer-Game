using JetBrains.Annotations;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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
    public Transform groundCheck;
    public float groundCheckRaduius;
    public LayerMask groundLayer;
    public bool isTouchingGround;


    public void KillPlayer()
    {
     
      //Destroy(gameObject);
      // _animator.SetBool("player_Death", true);
        //ReloadLevel();
    }

    private void ReloadLevel(int health)
    {
       if (health == 0)
        {
          _animator.SetBool("player_Death", true);
        }
        else
        {
            SceneManager.LoadScene(0);
            RestartMenu();
        }
    }
        
    private void RestartMenu()
    {
        
    }

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
    }

    public void PickUpKeys()
    {
        _scoreController.AddScore(10);
    }

    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        MoveCharecter(horizontal);
        Crouch();
        HorizontalAnimation(horizontal);

        if (Input.GetButtonDown("Jump"))
        {
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
    private void OnTriggerEnter2D(Collider2D other)
    {


        if(other.gameObject.CompareTag("MovingPlatform"))
        {
            player.transform.parent = other.gameObject.transform;
        }
    }
}
