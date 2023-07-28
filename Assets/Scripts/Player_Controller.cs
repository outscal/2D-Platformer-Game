using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    Score_Manager scoreManager;

    [SerializeField]
    float speed;

    [SerializeField]
    float jumpForce;

    [SerializeField]
    GameObject livesHolder;

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
       //Here lives gets decreased and heart will be set to inactive
        if (lives > 0)
        {
            lives--;
            livesHolder.transform.GetChild(lives).gameObject.SetActive(false);
            isAlive = true;
            //Debug.Log(lives);
        }
        
        if (lives <= 0)
        {
            isAlive = false;
        }
    }


    //Death Function
    public void playerDeath()
    {
        //Death Animation
        animator.SetTrigger("Death");
        //Screen reload scene from level controller
        ReloadScene(2f);

    }
    //Reload Function
    public void ReloadScene(float seconds)
    {
        Invoke("LoadScene", seconds);
    }

    //Delays the Load scene
    public void LoadScene()
    {
        SceneManager.LoadScene(0);
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
