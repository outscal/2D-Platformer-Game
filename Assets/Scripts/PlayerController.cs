using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health ;
    const string HORIZONTAL = "Horizontal";
    const string JUMP = "Jump";
    const string CROUCH = " Crouch";
    const string GROUNDED = "isGrounded";
    [SerializeField] int scorePerKey;
    public SceneLoader sceneLoader;
    public JumpCollider jumpCollider;
    [Range(0,10)][SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    public Animator animator;
    public ScoreController scoreController;
    Rigidbody2D rb2d;
    BoxCollider2D boxCollider;
    bool isGrounded;
    bool isDead;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Health: " + health);
        if (collision.gameObject.GetComponent<EnemyController>() != null && health>0)
        {
            health--;
            if (health == 0)
            {
                StartCoroutine(PlayerDeath());
            }
        }
    } 
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Health: " + health);
    }
    
    IEnumerator PlayerDeath()
    {
        animator.SetBool("Dead", true);
        yield return new WaitForSeconds(1);
        sceneLoader.ReloadScene();
    }
    public void PickUpKey()
    {
        scoreController.IncreaseScore(scorePerKey);
    }

    
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw(HORIZONTAL); 
        float crouch = Input.GetAxisRaw("Crouch");
        float jump = Input.GetAxisRaw(JUMP);
        animator.SetBool(GROUNDED, isGrounded);
        JumpAnimation(jump);
        MoveAnimation(horizontal);
        CrouchAnimation(crouch);
        PlayerMovement(horizontal,crouch,jump);

        isGrounded = jumpCollider.GrounChecker();
    }

    private void PlayerMovement(float horizontal,float crouch,float jump)
    {
        if (!animator.GetBool("Dead"))
        {
            Vector3 playerPos = transform.position;
            if (crouch > 0)
            {
                playerPos.x += horizontal * moveSpeed * Time.deltaTime * 0.2f;
            }
            else
            {
                playerPos.x += horizontal * moveSpeed * Time.deltaTime;
            }
            transform.position = playerPos;

            if (jump > 0 && isGrounded)
            {
                rb2d.AddForce(new Vector2(0, jumpForce));
            }
        }
        

    }

    private void CrouchAnimation(float crouch)
    {
        
        if (crouch > 0)
        {
            animator.SetBool("isCrouch", true);
            boxCollider.offset = new Vector2(-0.17f, 0.60f);
            boxCollider.size = new Vector2(0.88f, 1.38f);
        }
        else
        {
            animator.SetBool("isCrouch", false);
            boxCollider.offset = new Vector2(0.024f, 1.01f);
            boxCollider.size = new Vector2(0.62f, 2.07f);
        }
    }

    private void MoveAnimation(float horizontal)
    {

        if (!animator.GetBool("Dead"))
        {
            float absHorizontal = Mathf.Abs(horizontal);
            animator.SetFloat("Speed", absHorizontal);
            Vector3 scale = transform.localScale;
            if (horizontal > 0)
            {
                scale.x = absHorizontal;
            }
            else if (horizontal < 0)
            {
                scale.x = -1f * absHorizontal;
            }
            transform.localScale = scale;
        }
        
    }

    private void JumpAnimation(float jump)
    {
        
        if (jump > 0)
        {
            animator.SetBool("Jump", true);
        }
        else 
        {
            animator.SetBool("Jump", false);
        }
    }
}
