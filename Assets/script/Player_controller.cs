using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_controller : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator animator;
    
    public float speed;
    public float jump;

    // for heart and game over 

    public GameObject Heart1, Heart2, Heart3, gameOver;
    public static int health;


    private void Start()
    {
        health = 3;
        Heart1.gameObject.SetActive(true);
        Heart2.gameObject.SetActive(true);
        Heart3 .gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
    }

   


    private Rigidbody2D rigi2D;
    private void Awake()
    {
        Debug.Log(" player controller awake ");
        rigi2D = gameObject.GetComponent<Rigidbody2D>();
      // rigi2D = GetComponent<Animator>();
    }

    public void KillPlayer()
    {
        Debug.Log("player was killed by enemy");
        Destroy(gameObject);
        ReloadLevel();
    }

    private void ReloadLevel()
    {
        Debug.Log("Reloading scene 0");
        SceneManager.LoadScene(0);
    }

    public void PickUpKey()
    {
        Debug.Log("player picked up the key");
        scoreController.IncreaseScore(10);
    }

    private void Update()
    {      // for moving character horizontally

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal, vertical);

        // for moving character vertically

        if (vertical > 0)
        {
            rigi2D.AddForce(new Vector2(0f , jump), ForceMode2D.Force);

        }
        // update is called onces per frame
        // for heart and gameover function

        if(health > 3)
            health = 3;

        switch (health)
        {
            case 3:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                break;
            case 2:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(false);
                break;
            case 1:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                break;
            case 0:
                Heart1.gameObject.SetActive(false);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
               // Time.timeScale = 0;
                KillPlayer();
                break;


        }
    }
    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        // (distance / time(sec)) * ( 1/ 30 sec)
        
        //a = a+b
        // can be writen as a+=b
        position.x += horizontal * speed * Time.deltaTime;                        // for movement of the chearctor
        transform.position = position;
    }

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

         // for jumping
        

        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {  
            animator.SetBool("Jump", false);           
        }

        //Input.GetKeyDown(KeyCode.RightControl );

        if (animator == true && Input.GetKey(KeyCode.Z))
        {
            animator.SetTrigger("takeof");
            
            
        }





    }
}       
