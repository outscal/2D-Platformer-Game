using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] Score_Manager scoreManager;

    [SerializeField] float speed;

    [SerializeField] float jumpForce;

    [SerializeField] Transform startPosition;

    [SerializeField] Camera mainCamera;

    [SerializeField] Image [] hearts;

    bool isGrounded;

    Rigidbody2D rb;

    int lives = 3;

    public bool isAlive;


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {

        PlayerMovement();
    }

    //Pick key function
    public void PickKey()
    {
        scoreManager.IncreaseScore(10);
    }


    //Player movement function
    private void PlayerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        HorizontalMove(horizontal);

        float vertical = Input.GetAxisRaw("Jump");
        Jump(vertical);

        Crouch();
    }


    //Horizontal move
    private void HorizontalMove(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //setting the speed parameter to animator
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        //Accessing the scale of the player
        Vector3 scale = transform.localScale;

        //if speed < 0 flip the image in x-axis 
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0) //If speed > 0 then keep the x-axis value positive
        {
            scale.x = Mathf.Abs(scale.x);
        }
        //Set the scale value
        transform.localScale = scale;
    }

   

    //Verticle move
    private void Jump(float vertical)
    {
        if (vertical > 0 && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            isGrounded = false;
        }

    }

    //Crouch function
    private void Crouch()
    {
        //Crouch
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            //Set crouch animation
            animator.SetBool("Crouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            //Set crouch animation
            animator.SetBool("Crouch", false);
        }

    }

    //Decrease Life
    public void DecreaseLife()
    {
        lives--;
        HandleHealthUI();

        if (lives <= 0)
        {
            playerDeath();
        }
        else
        {
            Invoke(nameof(PlayerInvoke), 0.25f);
        }
    }

    //Delays the invoke of the player when player loses the life
    private void PlayerInvoke()
    {
        transform.position = startPosition.position;
    }


    //Death Function
    public void playerDeath()
    {
        isAlive = false;
        
        //Death Animation
        animator.SetTrigger("Death");
     
        //Screen reload scene from level controller
        ReloadScene(2f);

    }

    private void HandleHealthUI()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            hearts[i].color = i < lives ? Color.red : Color.black;
        }
    }



    //Reload Function
    void ReloadScene(float seconds)
    {
        Invoke(nameof(LoadScene), seconds);
    }

    //Delays the Load scene
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Collision enter check
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            //Debug.Log("Grounded");
        }
    }

    //Collision exit check
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("not Grounded");
            isGrounded = false;
        }
    }
}
