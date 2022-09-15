using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator player_animator;
    BoxCollider2D player_boxCollider;
    Rigidbody2D player_rb2D;

    public bool isCrouch;
    public bool canJump;
    public int jumpsRemaining;

    [Header("Hitbox")]
    public Vector2 standingColliderOffset;
    public Vector2 standingColliderSize;
    public Vector2 crouchColliderOffset;
    public Vector2 crouchColliderSize;

    [Header("Movement")]
    public float speed;
    public float jumpForce;
    public int maxJumps;

    private void Awake()
    {
        player_rb2D = GetComponent<Rigidbody2D>();
        player_boxCollider = GetComponent<BoxCollider2D>();
        player_animator = GetComponent<Animator>();
    }

    private void Start()
    {
        jumpsRemaining = maxJumps;
    }


    void Update()
    {
        float moveValue = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonUp("Jump") && !isCrouch)
        {
            if(jumpsRemaining > 0)
            {
                --jumpsRemaining;
                canJump = true;
            }
            else
            {
                canJump = false;
            }
        }

        PlayMovementAnimation(moveValue);
        MovePlayer(moveValue);
    }

    private void FixedUpdate()
    {
        if (canJump)
        {
            player_rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            canJump = false;
        }
    }

    private void MovePlayer(float xAxis)
    {
        transform.position += Vector3.right * xAxis * speed * Time.deltaTime;
    }

    private void PlayMovementAnimation(float xAxis)
    {
        player_animator.SetFloat("Speed", Mathf.Abs(xAxis));

        Vector3 scale = transform.localScale;

        if (xAxis < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (xAxis > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;


        player_animator.SetBool("Jump", canJump);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            isCrouch = true;
            player_animator.SetBool("Crouch", true);
            CrouchHitBox(true);
        }
        else
        {
            isCrouch = false;
            player_animator.SetBool("Crouch", false);
            CrouchHitBox(false);
        }
    }

    private void CrouchHitBox(bool crouch)
    {
        if(crouch)
        {
            player_boxCollider.offset = crouchColliderOffset;
            player_boxCollider.size = crouchColliderSize;
        }
        else
        {
            player_boxCollider.offset = standingColliderOffset;
            player_boxCollider.size = standingColliderSize;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<CollisionEnums>().colliderTag == ColliderTags.GROUND)
        {
            jumpsRemaining = maxJumps;
        }
    }
}
