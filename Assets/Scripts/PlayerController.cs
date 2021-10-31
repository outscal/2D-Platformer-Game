using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator animator;
    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;
    public GameOverController gameOverController;
    private void Awake()
    {
        Debug.Log("Player Controller Awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    public void KillPlayer()
    {
        Debug.Log("Player Killed by enemy:");
        if(health>0)
        {
            health=health-1;
            PlayerPrefs.SetInt("Health",health);
            gameOverController.ReloadLevel();
            Debug.Log("Health now" + health);
        }
        else
        {
            gameOverController.PlayerDied();
        }
    }
    public void PickUpKey()
    {
        Debug.Log("Player picked the Key");
        scoreController.IncreaseScore(5);
    }
    private void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Jump");
        PlayerMovementAnimation(Horizontal,Vertical);
        MoveCharacter(Horizontal,Vertical);
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i<health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i<numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
                
            }
        }
    }
    public void PlayerDeathAnimation(bool Impact)
    {
        if (Impact == true)
        {
            animator.SetBool("AnimDeath",true);
        }
        else
        {
            animator.SetBool("AnimDeath",false);
        }
    }
    private void PlayerMovementAnimation(float Horizontal,float Vertical)
    {
        animator.SetFloat("AnimSpeed", Mathf.Abs(Horizontal));

        //Horizontal Animator Panel
        Vector3 scale = transform.localScale;
        if (Horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(Horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Jump Animator Panel
        if (Vertical > 0)
        {
            animator.SetBool("AnimJump", true);
        }
        else
        {
            animator.SetBool("AnimJump", false);
        }

        //Crouch Animator Panel
        bool Crouch = Input.GetKeyUp(KeyCode.LeftControl);
        if (Crouch == true)
        {
            animator.SetBool("AnimCrouch", true);
        }
        else
        {
            animator.SetBool("AnimCrouch", false);
        }
    }
    private void MoveCharacter(float Horizontal,float Vertical)
    {
        //move character horizontally
        Vector3 position = transform.position;
        position.x += Horizontal*speed*Time.deltaTime;
        transform.position = position;

        //move character vertically
        if(Vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f,jump), ForceMode2D.Force);
        }
    }
    
}
