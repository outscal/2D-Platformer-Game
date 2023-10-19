using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0;

    [SerializeField] private float jumpForce = 0;

    private SpriteRenderer playerSprite_R;

    private Animator playerAnimator;

    private Rigidbody2D playerRb;

    private float moveValue = 0;

    private bool isCrouch = false;

    private const string ISJUMP = "IsJump";
    private const string ISCROUCH = "IsCrouch";

    private void Start()
    {
        isCrouch = false;
        InitComponents();
    }

    private void InitComponents()
    {
        playerSprite_R = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        //input approach 1 smooth movement 
        /*moveValue = Input.GetAxis("Horizontal");*/

        //input approach 2 raw Movement and time.deltatime 
        moveValue = Input.GetAxisRaw("Horizontal");
        if (moveValue > 0)
        {

            //sprite flip approach1 scale 
            transform.localScale = Vector3.one;
            //sprite flip approach2 flip value

        }

        if (moveValue < 0)
        {
            //sprite flip approach1 scale 
            transform.localScale = new Vector3(-1, 1, 1);
            //sprite flip approach2 flip value
            //playerSprite_R.flipX = true;
        }

        playerAnimator.SetFloat("Speed", Mathf.Abs(moveValue));

        Jump();
        Crouch();
    }

    private void FixedUpdate()
    {
        if (!isCrouch)
        {
            Vector2 finalMoveValue = new(moveValue * speed * Time.fixedDeltaTime, playerRb.velocity.y);

            playerRb.velocity = finalMoveValue;
        }
       
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(jumpForce * Vector3.up, ForceMode2D.Impulse);

            SetBoolAnimation(ISJUMP, true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            SetBoolAnimation(ISJUMP, false);
        }
    }

    private void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isCrouch = true;

            SetBoolAnimation(ISJUMP,false);
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
}
