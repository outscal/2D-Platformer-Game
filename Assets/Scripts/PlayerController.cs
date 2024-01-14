using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{ 
[SerializeField] private Animator animator;
[SerializeField] private float Speed = 0f;
[SerializeField] private float jump = 0f;
private Rigidbody2D rb;
private bool isGrounded;
[SerializeField] private ScoreManager scoreManager;
[SerializeField] private PlayerHealth playerHealth;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        animator.SetBool("Died", false);
    }

    private void Update()
    {

        float vert = Input.GetAxisRaw("Vertical");
        float horiz = Input.GetAxisRaw("Horizontal");

        if(animator.GetBool("Crouch") == false)
        {
            PlayerMove(horiz, vert);
            PlayerMoveAnim(horiz, vert);
        }
        

        //for crouch
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        else
        {
            animator.SetBool("Crouch", false);
        }
        if(isGrounded)
        {
            animator.SetBool("Grounded", true);
        }
        else
        {
            animator.SetBool("Grounded", false);
        }
    }

    private void PlayerMove(float horiz, float vert)
    {
        Vector3 position = transform.position;

        position.x = position.x + (horiz * Speed * Time.deltaTime);
        transform.position = position;

        //for jump
        if(vert>0 && isGrounded == true)
        {
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);

        }
    }
    public void KeyPickUp()
    {
        Debug.Log("Key Picked Up!");
        scoreManager.setScore(10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("gorund");
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("gorund no");
            isGrounded = false;
        }
    }

    private void PlayerMoveAnim(float horiz, float vert)
    {
        animator.SetFloat("Speed", Mathf.Abs(horiz));
        Vector3 scale = transform.localScale;


        if (horiz < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horiz > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        //for Jump
        if (vert > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        transform.localScale = scale;
    }

    public void HurtPlayer()
    {
        if(playerHealth.health >= 1 )
        {
            playerHealth.LooseHealth();
        }
        else
        {
            animator.SetBool("Died", true);
            Debug.Log("Killer by Chomper");
            StartCoroutine(DeathReload());
        }
        
    }

    IEnumerator DeathReload()
    {
        //animator.SetBool("Died", false);
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}