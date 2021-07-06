using UnityEngine;
using UnityEngine.UI;

namespace Elle2D{
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private CapsuleCollider2D capCollider2D;
    private Rigidbody2D rb2D;

    [Header("Crouch position")]
    [SerializeField] float crouchOffsetx;
    [SerializeField] float crouchOffsety;
    [SerializeField] float crouchSizex, crouchSizey;
    [SerializeField] float offsetx, offsety;
    [SerializeField] float sizex, sizey;
    private bool gameOver;
    [Header("Movement Setting")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float downForce;
    private bool onGround;
    private int jumpCount = 0;

    [Header("Health Setting")]
    [SerializeField] int livesRemain = 1;
    [SerializeField] Image[] heart;
    [SerializeField] Text scoreText;
    // public Text totalScoreText;
    [SerializeField] Image gameOverButtonImage;
    public Image nextSceneButtonImage;
    [SerializeField] ScoreController scoreController;
    private int scoreValue = 10;
    [HideInInspector] public bool isFacingRight = true;
    [HideInInspector] public bool withGun = false;
    private AudioSource audioSource;
    [SerializeField] AudioClip[] PlayerSounds;
    private float volume = 0.5f;

    private enum Sounds
    {
        key,
        playerDied,
        jump,
        fire
    }

    //<summry>
    // awake is used to intialize any variable or game state before game starts
    // awake is always called before satrt function

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        capCollider2D = GetComponent<CapsuleCollider2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    public void PickUpKey()
    {
        audioSource.PlayOneShot(PlayerSounds[(int)(Sounds.key)], volume);
        scoreController.increaseScore(scoreValue);
    }

    //<summry>
    // killPlayer will reduce health by one and reload player to start position
    // after three chance game over button will pop up
    public void KillPlayer()
    {
        audioSource.PlayOneShot(PlayerSounds[(int)(Sounds.playerDied)], volume);
        livesRemain--;
        transform.position = new Vector3(0, 0, 0);
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
        gameOverButtonImage.gameObject.SetActive(true);
        scoreText.text = "Total Score: " + scoreController.score.ToString();
    }

    //this update function will deactivate heart compoenent
    private void updateLifeUI()
    {
        if (livesRemain == 3)
        {
            heart[0].gameObject.SetActive(true);
            heart[1].gameObject.SetActive(true);
            heart[2].gameObject.SetActive(true);
        }
        if (livesRemain == 2)
        {
            heart[0].gameObject.SetActive(true);
            heart[1].gameObject.SetActive(true);
            heart[2].gameObject.SetActive(false);
        }
        if (livesRemain == 1)
        {
            heart[0].gameObject.SetActive(true);
            heart[1].gameObject.SetActive(false);
            heart[2].gameObject.SetActive(false);
        }
        if (livesRemain == 0)
        {
            heart[0].gameObject.SetActive(false);
            heart[1].gameObject.SetActive(false);
            heart[2].gameObject.SetActive(false);
            gameOver = true;
        }
    }

    ///from here script is for  movement
    private float horizantal;
    private float vertical;
    private bool crouch;
    private void Update()
    {
        horizantal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Jump");      //use "Jump" or "Vertical" both are same
        crouch = Input.GetKey(KeyCode.DownArrow);

    }

    private void FixedUpdate()
    {
        MoveCharacter(horizantal, vertical);
        PlayMovementAniamation(horizantal, vertical, crouch);
    }

    // checking Player on ground or not and setting bool onGround
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            onGround = true;
        }
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            onGround = true;
            transform.parent = collision.transform;
            rb2D.gravityScale = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            onGround = false;
        }
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            onGround = false;
            transform.parent = null;
            rb2D.gravityScale = 1;
        }
    }

    private void MoveCharacter(float horizantal, float vertical)
    {
        RunChar(horizantal);
        JumpChar(vertical);
    }

    void RunChar(float horizantal)
    {
        Vector3 pos = transform.position;
        pos.x += horizantal * speed * Time.deltaTime;
        transform.position = pos;
    }

    void JumpChar(float vertical)
    {
        if ((vertical > 0) && (onGround == true))
        {
            rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            onGround = false;
        }

    }
    private void PlayMovementAniamation(float horizantal, float vertical, bool crouch)
    {
        RunAnim(horizantal);
        JumpAnim(vertical);
        CrouchAnim(crouch);
        IdleWithGun();
    }


    private void IdleWithGun()
    {
        if (Input.GetButton("Fire1"))
        {

            audioSource.PlayOneShot(PlayerSounds[(int)Sounds.fire], volume);
            withGun = true;
            animator.SetBool("WithGun", true);
        }
        else
        {
            withGun = false;
            animator.SetBool("WithGun", false);
        }
    }

    //RunAnim fun for run animation
    void RunAnim(float horizantal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizantal));
        Vector3 scale = transform.localScale;
        if (horizantal < 0)
        {
            isFacingRight = false;
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (horizantal > 0)
        {
            isFacingRight = true;
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
    void JumpAnim(float vertical)
    {
        if (vertical > 0 && rb2D.velocity.y > 0)
        {
            if (jumpCount == 0 && onGround == false)
            {

                audioSource.PlayOneShot(PlayerSounds[(int)Sounds.jump], volume);
                animator.SetBool("IsJump", true);
                jumpCount = 1;
            }
            animator.SetBool("JumpFall", false);
        }
        else
        {
            animator.SetBool("JumpFall", true);
            animator.SetBool("IsJump", false);
            rb2D.velocity = new Vector2(0.0f, downForce);

            if (onGround == true)
            {
                jumpCount = 0;
                animator.SetBool("JumpFall", false);

            }
        }
        if ((rb2D.velocity.y == 0) && (onGround == true))
        {
            animator.SetBool("JumpFall", false);
        }

        if (onGround == false)
        {
            animator.SetBool("JumpFall", true);
        }
    }

    //CrouchAnim fun for crouch animation
    void CrouchAnim(bool crouch)
    {
        if (crouch == true)
        {
            animator.SetBool("IsCrouch", crouch);
            capCollider2D.offset = new Vector2(crouchOffsetx, crouchOffsety);
            capCollider2D.size = new Vector2(crouchSizex, crouchSizey);
        }
        else
        {
            animator.SetBool("IsCrouch", crouch);
            capCollider2D.offset = new Vector2(offsetx, offsety);
            capCollider2D.size = new Vector2(sizex, sizey);
        }
    }
}
}