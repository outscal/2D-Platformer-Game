using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;
    public BoxCollider2D boxCollider2D;
    public ScoreController scoreController;
    public GameObject[] hearts;  // Array to hold heart UI elements

    public int maxHealth = 3;
    private int currentHealth;

    private Rigidbody2D rb2d;
    private Vector2 offsetx;
    private Vector2 offsety;

    private void Awake()
    {
        Debug.Log("Player controller awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    private void Start()
    {
        offsetx = boxCollider2D.size;
        offsety = boxCollider2D.offset;

        UpdateHeartUI();  // Corrected method name
    }

    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal, vertical);
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        if (vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
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

        if (vertical > 0)
        {
            animator.SetBool("IsJump", true);
        }
        else
        {
            animator.SetBool("IsJump", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Crouch(true);
        }
        else
        {
            Crouch(false);
        }
    }

    public void Crouch(bool crouch)
    {
        if (crouch)
        {
            boxCollider2D.size = new Vector2(0.6988f, 1.3398f);
            boxCollider2D.offset = new Vector2(-0.0978f, 0.5947f);
        }
        else
        {
            boxCollider2D.size = offsetx;
            boxCollider2D.offset = offsety;
        }

        animator.SetBool("Crouch", crouch);
    }

    public void PickUpKey()
    {
        Debug.Log("Player picked up the key");
        scoreController.IncreaseScore(10);
    }

    public void TakeDamage()  // Corrected method name
    {
        currentHealth--;
        Debug.Log("Player Health : " + currentHealth);

        UpdateHeartUI();  // Update the heart UI

        if (currentHealth <= 0)
        {
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        Debug.Log("Player killed by the enemy");
        animator.SetTrigger("Die");
        this.enabled = false;

        Invoke("ReloadLevel", 0.5f);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

    private void UpdateHeartUI()  // Corrected method name
    {
        for (int i = 0; i < hearts.Length; i++)  // Corrected to Length
        {
            hearts[i].SetActive(i < currentHealth);
        }
    }
}
