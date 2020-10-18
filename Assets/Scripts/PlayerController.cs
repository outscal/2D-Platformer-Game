 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public GameOverController gameOverController;
    public Rigidbody2D rgbd2D;
    public Animator animator;
    public float speed;
    public float jump;
    private bool canJump;
    public bool isGrounded;

//    public float jumpSpeed  = 10f;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    
    

    public void KillPlayer()
    {
        Debug.Log("Player Killed by enemy");
        // Destroy(gameObject);
        gameOverController.PlayerDied();
        this.enabled = false;
    }

   

    private void Awake() {
      Debug.Log("Player Controller awake");
      rgbd2D = gameObject.GetComponent<Rigidbody2D>();
   }

   void Start() {
        rgbd2D = GetComponent<Rigidbody2D>();
   }

    public void PickUpKey()
    {
        Debug.Log("Player picked up the key");
        scoreController.IncreaseScore(10);
    }

    // private void OnCollisionEnter2D(Collision2D collision) {
    //    Debug.Log("Collision: " + collision.gameObject.name);
    // }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal, vertical);
        checkSurroundings();
        // can_Jump();
    }

    private void MoveCharacter(float horizontal, float vertical){
       //Move Horizontally
        Vector3 position  = transform.position;
        position.x +=  horizontal *speed * Time.deltaTime;
        transform.position = position;

        if(vertical > 0)
        {
            rgbd2D.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }
    }

    // void Jump(){
    //     //Move Vertically
    //     // if (canJump)
       
    // }

    private void checkSurroundings(){
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    // private void can_Jump(){
    //     if(isGrounded && rgbd2D.velocity.y <= 0){
    //         canJump = true;
    //     }
    //     else{
    //         canJump = false;
    //     }
    // }

    private void PlayMovementAnimation(float horizontal, float vertical)
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

        // //Jump
        if(vertical > 0){
            animator.SetBool("Jump", true);
        }
        else{
            animator.SetBool("Jump", false);
        }

        // if(Input.GetButtonDown("Space")){
        //     Jump();
        // }

        //crouch
        if(Input.GetKey(KeyCode.LeftControl)){
            animator.SetBool("isCrouch", true);
        }
        else{
            animator.SetBool("isCrouch", false);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}

     