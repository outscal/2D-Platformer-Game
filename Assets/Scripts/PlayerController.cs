using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator animator;
    public float speed;
    public float jumpForce;
    private bool isGrounded = true;
    private bool isCrouching = false;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCol;
    public int playerHealth;
    [SerializeField] private Image[] hearts;
    public Transform startPosition;
    //private bool isDead = false;
    [SerializeField] private GameObject mainCamera; 


    private void Awake()
    {
        Debug.Log("Player controller awake");
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        boxCol = this.GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        startPosition.position = transform.position;
        UpdateHealthUI();
    }

    private void Update()
    {
        //for running animation
        float horizontalInput = Input.GetAxisRaw("Horizontal");       
        float verticalInput = Input.GetAxisRaw("jump");               

        MoveCharacter(horizontalInput, verticalInput);
        PlayMovementAnimation(horizontalInput, verticalInput);
        Crouch(isCrouching);
    }

    private void MoveCharacter(float horizontalInput, float verticalInput)
    {
        //move character horizontally 
        Vector3 position = transform.position;
        position.x += horizontalInput * speed * Time.deltaTime;  
        transform.position = position;

        //move chararcter vertically
        if (verticalInput > 0 && isGrounded)
        {
            rigidbody2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void PlayMovementAnimation(float horizontalInput, float verticalInput)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        Vector3 scale = transform.localScale;
        if(horizontalInput < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if(horizontalInput > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Jump
        if(verticalInput > 0)                         
        {
            animator.SetBool("Jump", true); 
            animator.SetFloat("Speed", 0);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    //Crouching
    private void Crouch(bool crouch)
    {
        crouch = isCrouching;
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isCrouching = true;
            animator.SetBool("Crouch", isCrouching);
        }
        else 
        {
            isCrouching = false;
            animator.SetBool("Crouch", isCrouching);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true; 
        } 
    }
    
    public void PickUpKey()
    {
        Debug.Log("Player picked up the key");
        scoreController.IncreaseScore(10);
    }

    public void DecreaseHealth()
    {
        playerHealth--;
        UpdateHealthUI();
        if (playerHealth <= 0)
        {
            PlayDeathAnimation();
            PlayerDeath();
        }
        else 
        {
            transform.position = startPosition.position;
        }
    }

    public void PlayerDeath()
    {
        //isDead = true;
        mainCamera.transform.parent = null;
        // Setting death UI panel to active
        rigidbody2d.constraints = RigidbodyConstraints2D.FreezePosition;
        StartCoroutine("Dead");
    }

    public void UpdateHealthUI()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < playerHealth)
            {
                hearts[i].color = Color.red;
            }
            else
            {
                hearts[i].color = Color.black;
            }
        }
    }

    public void PlayDeathAnimation()
    {
        animator.SetTrigger("Death");
    }

    //Death Collider, scene reload
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "DeathCollider")
        {
            PlayDeathAnimation();
            StartCoroutine("Dead");
        }
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(1f);
        ReloadLevel();
    }
    public void ReloadLevel()
    {
        Debug.Log("Reloading Scene 0");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);      //Can also do with SceneManager.LoadScene(0);
    }
}