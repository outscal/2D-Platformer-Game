using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private SpriteRenderer[] hearts;

    [SerializeField] private GameObject deathUIPanel;

    private bool isCrouching = false;

    private int health;
    private Camera mainCamera;

    private bool isDead = false;

    private void Awake()
    {
        // Debug.Log("Player Controller Awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = hearts.Length;

        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        MoveCharacter(horizontal, vertical);

        PlayeMovementAnimation(horizontal, vertical);
    }

    void MoveCharacter(float horizontal, float vertical)
    {
        // moving horizontal
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        // moving vertical
        if (vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }
    }

    void PlayeMovementAnimation(float horizontal, float vertical)
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

        /* 
         * bool isJumping = false;
         if (Input.GetKeyDown(KeyCode.Space))
         {
             isJumping = true;
         }
         animator.SetBool("Jump", isJumping);
        */

        // new jump
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        
        //if(Input.GetKeyDown(KeyCode.LeftControl))
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //animator.SetBool("Crouch", true);
            isCrouching = true;
           

        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Debug.Log("GET KEY UP");
            isCrouching = false;
            Debug.Log("isCouching false");
           
            //animator.SetBool("Crouch", false);
            //animator.SetTrigger("Idle");
        }
        //else {}
        animator.SetBool("Crouch", isCrouching);

       
    }

    public void PickUpKey()
    {
        Debug.Log("Player Picked the key");
        scoreController.IncreaseScore(10);
    }

    
    public void KillPlayer()
    {
        Debug.Log("Player Killed by Enemy");
        //Destroy(gameObject);
        // play the death animation

        // Reset entire level
        ReloadLevel();

    }

    /*
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>() != null)
        {
            PlayerHealth playerHealth = GetComponent<PlayerHealth>();
            playerHealth.TakeDamage();
        }
    }
    */

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DecreaseHealth()
    {
        health--;

        HandleHealthUI();
        if (health <= 0)
        {
            PlayDeathAnimation();
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        isDead = true;
        mainCamera.transform.parent = null;
        deathUIPanel.gameObject.SetActive(true);
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
        ReloadLevel();
    }

    public void PlayDeathAnimation()
    {
        playerAnimator.SetTrigger("Die");
    }

    public void HandleHealthUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].color = (i < health) ? Color.red : Color.black;
        }
    }
}