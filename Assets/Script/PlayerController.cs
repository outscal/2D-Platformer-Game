using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    // public float jump;
    public BoxCollider2D boxCollider2D;
    private Rigidbody2D rb2D;

    private int livesRemain = 3;
    private bool gameOver;
    public Image life01;
    public Image life02;
    public Image life03;
    Vector3 startPos;
    private Text scoreText;
    public Text highScoreText;
    public Button gameOverButton;

    public ScoreController scoreController;
    public string restartScene;

    private int scoreValue = 10;
    bool onGround = true;

    //awake is used to intialize any variable or game state before game starts
    //awake is always called before satrt function
    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    //PickUpKey() = this will increases score after key pick
    public void PickUpKey()
    {
        scoreController.increaseScore(scoreValue);
    }

    //killPlayer will reduce health by one and reload player to start position
    //after three chance game over button will pop up
    public void KillPlayer()
    {
        livesRemain--;
        transform.position = new Vector3(-80, -1.5f, 0);
        transform.localScale = new Vector3(2, 2, 2);
        updateLifeUI();
        if (gameOver == true)
        {
            GameOverButtonText();
        }
    }

    //this text func helps in showing final score
    public void GameOverButtonText()
    {
        gameOverButton.gameObject.SetActive(true);
        highScoreText.text = "Total Score: " + scoreController.score.ToString();
    }

    //this update fun will deactivate heart compoenent
    private void updateLifeUI()
    {
        if (livesRemain == 3)
        {
            life01.gameObject.SetActive(true);
            life02.gameObject.SetActive(true);
            life03.gameObject.SetActive(true);
        }
        if (livesRemain == 2)
        {
            life01.gameObject.SetActive(true);
            life02.gameObject.SetActive(true);
            life03.gameObject.SetActive(false);
        }
        if (livesRemain == 1)
        {

            life01.gameObject.SetActive(true);
            life02.gameObject.SetActive(false);
            life03.gameObject.SetActive(false);
        }
        if (livesRemain == 0)
        {

            life01.gameObject.SetActive(false);
            life02.gameObject.SetActive(false);
            life03.gameObject.SetActive(false);
            gameOver = true;
        }
    }

    //this func help inn reloading scene with the help of game over button
    public void ReloadScene()
    {
        SceneManager.LoadScene(restartScene);
    }

    private void Update()
    {
        float horizantal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");      //use "Jump" or "Vertical" both are same
        
        bool crouch = Input.GetKey("left ctrl");

        MoveCharacter(horizantal, vertical);
        PlayMovementAniamation(horizantal, vertical, crouch);

    }

    private void MoveCharacter(float horizantal, float vertical)
    {
        //Move horizaontally
        RunChar(horizantal);

        // Move Verically
        JumpChar(vertical);

    }

    //this RunChar func will run our player
    void RunChar(float horizantal)
    {
        Vector3 pos = transform.position;
        pos.x += horizantal * speed * Time.deltaTime;
        transform.position = pos;
    }

    // //JumpChar func will do jump our player
    void JumpChar(float vertical)
    {
        // if (vertical > 0 && onGround == true)
        if (vertical > 0)
        {
            // rb2D.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
            rb2D.velocity = new Vector2(0.0f,6.0f);
            // onGround = false;
            // rb2d.velocity = new Vector2(0.0f, -10.0f);
        }
        else //if(onGround==false)
        {
            rb2D.velocity = new Vector2(0.0f, -6.0f);
            onGround = true;

        }
    }

    // this will control animation
    private void PlayMovementAniamation(float horizantal, float vertical, bool crouch)
    {
        RunAnim(horizantal);
        JumpAnim(vertical);
        CrouchAnim(crouch);
    }

    //RunAnim fun for run animation
    void RunAnim(float horizantal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizantal));
        Vector3 scale = transform.localScale;
        if (horizantal < 0 )
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (horizantal > 0 )
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

    }

    // JumpAnim fun for jump animation
    void JumpAnim(float vertical)
    {
        if (vertical > 0 )
        {
            animator.SetBool("Jump", true);
        }
        else 
        {
            animator.SetBool("Jump", false);
        }
    }

    //CrouchAnim fun for crouch animation
    void CrouchAnim(bool crouch)
    {
        if (crouch == true)
        {
            animator.SetBool("Crouch", crouch);
            boxCollider2D.offset = new Vector2(-0.004810318f, 0.6084107f);
            boxCollider2D.size = new Vector2(0.4740263f, 1.351288f);

        }
        else
        {
            animator.SetBool("Crouch", crouch);
            boxCollider2D.offset = new Vector2(-0.004810318f, 0.9641527f);
            boxCollider2D.size = new Vector2(0.4740263f, 2.012844f);
        }
    }

}
