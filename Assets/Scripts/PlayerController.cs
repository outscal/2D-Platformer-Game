using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;

    public Animator anim;
    private float speed = 6f;
    private float jump = 7f;
    private Rigidbody2D rb;

    public GameObject gameOverPanal;

    [SerializeField]
    private bool isCrouching=false;
    public bool isGrounded;
    public bool isJumping;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        PlayerMovementAnimation(horizontal, vertical);
        MoveCharacter(horizontal, vertical);

        



    }

    public void PickUpKeys()
    {
        Debug.Log("Player picked up the key");
        scoreController.ScoreIncrease(10);
    }
    /*
    public void PlayerKill()
    {

        //Destroy(gameObject);
        //ReloadScene();
        //this.enabled = false;

    }

    public void ReloadScene()
    {
        //GameOverPanal();
        //SceneManager.LoadScene(0);
    }*/


    public void MoveCharacter(float horizontal, float vertical)
    {
        
        Vector2 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
        /*
        if (vertical>0)
        {
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }*/
    }


    public void PlayerMovementAnimation(float horizontal, float vertical)
    {

        if (isGrounded == true)
        {
            anim.SetFloat("Speed", Mathf.Abs(horizontal));
        }

        

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1 * Mathf.Abs(horizontal);
        }

        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(horizontal);

        }

        transform.localScale = scale;

        if (vertical>0 && isGrounded)
        {
            anim.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isJumping = true;
        }
        isJumping = false;

        if (Input.GetKeyDown(KeyCode.C))
        {
            anim.SetBool("Crouch", true);
            isCrouching = true;
        }

        else if (Input.GetKeyUp(KeyCode.C))
        {
            anim.SetBool("Crouch", false);
            isCrouching = false;
        }


        StaffAttackAnimation();

    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    public void GameOverPanal()
    {
        this.enabled = false;
        gameOverPanal.SetActive(true);
        
    }
    
    public void RestartGame()
    {
        //SceneManager.LoadScene(0);
        gameOverPanal.SetActive(false);
        SceneManager.LoadScene(0);
        //PlayerKill();
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
      
    }

    public void StaffAttackAnimation()
    {


        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("StaffAttck", true);
        }

        else
        {
            anim.SetBool("StaffAttck", false);
        }
    }

}
