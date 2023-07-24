using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public Vector3 respawnPoint;
    
    private Animator animator;
    public float Speed;
    public int playerHealth;
    public float jumpforce;
    private bool isOnGround; 
    public ScoreController scoreController;

    //private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
    public GameOverController gameOverController;
    private void Awake()
    {
        Debug.Log("Player Awake");
       rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    public void KillPlayer()
    {
       
        Debug.Log("Killed by an enemy");
       gameOverController.PlayerDied();
        this.enabled = false; 
    }
    public void PickUpKey()
    {
        
        Debug.Log("Player picked up the key");
        scoreController.IncreaseScore(10);      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = true;
        }      
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = false;
        }
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        //respawnPoint = transform.position;
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        // float vertical = Input.GetAxisRaw("Jump");
        bool jump = Input.GetKeyDown(KeyCode.Space);
        PlayerMoveAnimation(horizontal,jump);
        MoveCharacter(horizontal,jump);
       // CrouchAnimation();
    }
    private void MoveCharacter(float horizontal, bool jump)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * Speed * Time.deltaTime;
        transform.position = position;

        if(jump && isOnGround)
        {
            // rb2d.AddForce(new Vector2(0f, jump),ForceMode2D.Force);
            rb2d.velocity = Vector2.up * jumpforce;
        }
    }
    private void PlayerMoveAnimation(float horizontal, bool jump)
  {
    animator.SetFloat("Speed", Mathf.Abs(horizontal));
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
    //jump
    if (jump)
    {
        animator.SetBool("Jump", true);
    }
    else
    {
        animator.SetBool("Jump", false);
    }
  }
    //private void CrouchAnimation()
    //{
    //    if (Input.GetKeyDown(KeyCode.LeftControl))
    //    {
    //        animator.SetBool("Crouch", true);
    //    }
    //    else if (Input.GetKeyUp(KeyCode.LeftControl))
    //    {
    //        animator.SetBool("Crouch", false);
    //    }
    //}   
}


