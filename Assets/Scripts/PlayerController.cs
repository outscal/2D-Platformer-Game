using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Jump Setting")]
    [SerializeField] private float speed = 0;

    [SerializeField] private float jumpForce = 0;

    [SerializeField] private int extraJump;

    private int remainedJump;

    [Header("Ground Check Setting")]
    [SerializeField] private Transform groundCheck;

    [SerializeField] private LayerMask ground;

    [SerializeField] private float redius;

    [SerializeField] private ScoreUpdate scoreUpdate;

    private SpriteRenderer playerSprite_R;

    private Animator playerAnimator;

    private Rigidbody2D playerRb;

    private float horizontalMove = 0;

    private float vertical;

    private bool isCrouch = false;

    private const string ISJUMP = "IsJump";
    private const string ISCROUCH = "IsCrouch";

    private void Start()
    {
        InitValues();

        InitComponents();
    }

    private void InitValues()
    {
        remainedJump = extraJump;

        isCrouch = false;
    }

    private void InitComponents()
    {
        playerSprite_R = GetComponent<SpriteRenderer>();

        playerAnimator = GetComponent<Animator>();

        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        FaceDir();

        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        Jump();

        Crouch();

        IsDead();
    }

    private void FaceDir()
    {
        if (horizontalMove > 0)
        {
            //sprite flip approach1 scale 
            //transform.localScale = Vector3.one;

            //sprite flip approach2 flip value
            playerSprite_R.flipX = false;
        }

        if (horizontalMove < 0)
        {
            //sprite flip approach1 scale 
            //transform.localScale = new Vector3(-1, 1, 1);

            //sprite flip approach2 flip value
            playerSprite_R.flipX = true;
        }
    }

    private void IsDead()
    {
        if (playerRb.velocity.y < - 50)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate()
    {
        PlayerRun();
    }

    private void PlayerRun()
    {
        if (!isCrouch)
        {
            Vector2 finalMoveValue = new(horizontalMove * speed * Time.fixedDeltaTime, playerRb.velocity.y);

            playerRb.velocity = finalMoveValue;
        }
    }

    private bool IsGrounded()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, redius, ground);
        return isGrounded;
    }

    private void Jump()
    {
        CheckIfJumpPress();

        //when player touch the ground extraJump will reset;
        if (IsGrounded())
        {
            remainedJump = extraJump;
        }

        void Jump_Perform()
        {
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(jumpForce * Vector3.up, ForceMode2D.Impulse);

            SetBoolAnimation(ISJUMP, true);
        }

        void CheckIfJumpPress()
        {
            if (Input.GetKeyDown(KeyCode.Space) || vertical > 0)
            {
                Debug.Log("Space!");
                if (IsGrounded())
                {
                    Jump_Perform();
                }
                else if (!IsGrounded() && remainedJump > 0)
                {
                    Jump_Perform();
                    remainedJump--;
                }

            }
            else
            {
                SetBoolAnimation(ISJUMP, false);
            }
        }
    }

    private void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (IsGrounded())
            {
                playerRb.velocity = Vector2.zero;
            }

            isCrouch = true;

            SetBoolAnimation(ISJUMP, false);
            SetBoolAnimation(ISCROUCH, true);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouch = false;
            SetBoolAnimation(ISCROUCH, false);
        }
    }

    private void SetBoolAnimation(string animName, bool value)
    {
        playerAnimator.SetBool(animName, value);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, redius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IfKeyTrigger(collision);
    }

    private void IfKeyTrigger(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            scoreUpdate.IncreaseScore();
            if (other.TryGetComponent<Collactabe>(out Collactabe cm))
            {
                cm.PlayCollected();
            }
        }
    }
}