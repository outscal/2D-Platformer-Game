using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [Header("Crouch settings")]
    [SerializeField] private Vector2 crouchSize;
    [SerializeField] private Vector2 crouchOffset;
    private Vector2 initSize;
    private Vector2 initOffset;
    private CapsuleCollider2D playerCollider;

    private TriggerDetection _triggerDetection;
    private GroundCheck _groundCheck;
    private Rigidbody2D _rigidbody;

    public GameManagerScript _gameManager;

    private bool isPlayerAlive;

    private void Awake()
    {
        playerCollider = GetComponent<CapsuleCollider2D>();
        _groundCheck = GetComponentInChildren<GroundCheck>();
        _triggerDetection = GetComponentInChildren<TriggerDetection>();
        _rigidbody = GetComponent<Rigidbody2D>();
        initOffset = playerCollider.offset;
        initSize = playerCollider.size;
        isPlayerAlive = true;
    }
    private bool isJumping = false;

    private void Update()
    {
        if(!isPlayerAlive) { return; }

        float HoriInput = Input.GetAxisRaw("Horizontal");
        float VerInput = Input.GetAxisRaw("Vertical");

        PlayerMoveAnimation(HoriInput, VerInput);
        PlayerMove(HoriInput, VerInput);
        PlayWalkSound(HoriInput);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            PlayerCrouch(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            PlayerCrouch(false);
        }
    }

    private void PlayerMoveAnimation(float HoriInput, float VerInput)
    {
        anim.SetFloat("Speed", Mathf.Abs(HoriInput));

        Vector3 Scale = transform.localScale;
        if (HoriInput > 0)
        {
            Scale.x = 1 * Mathf.Abs(Scale.x);
        }
        else if (HoriInput < 0)
        {
            Scale.x = -1 * Mathf.Abs(Scale.x);
        }
        transform.localScale = Scale;

        if (_groundCheck.isGrounded())
        {
            if (VerInput > 0 && !isJumping)
            {
                anim.SetTrigger("Jump");
                isJumping = true;
            }
            else if (isJumping)
            {
                anim.SetTrigger("EndJump");
                isJumping = false;
            }
        }
    }

    private void PlayerCrouch(bool crouchInput)
    {
        if (crouchInput)
        {
            playerCollider.size = crouchSize;
            playerCollider.offset = crouchOffset;
            anim.SetTrigger("Crouch");
        }
        else
        {
            playerCollider.size = initSize;
            playerCollider.offset = initOffset;
            anim.SetTrigger("EndCrouch");
        }
    }

    private void PlayerMove(float hori, float ver)
    {
        /*var position = transform.position;
        position.x += hori * Time.deltaTime * speed;
        transform.position = position;*/

        var iniVelocity = _rigidbody.velocity;
        var xVelocity = hori * speed;
        var finalVelocity = new Vector2(xVelocity, iniVelocity.y);
        _rigidbody.velocity = finalVelocity;

        if (isJumping & _groundCheck.isGrounded() && !forceAdded) 
        {
            forceAdded = true;
            //_rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            Invoke(nameof(ResetJumpForce), 0.25f);
        }
    }

    private bool forceAdded = false;

    void ResetJumpForce()
    {
        forceAdded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _triggerDetection.TriggerResponse(collision.tag);
        if(collision.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
        }
    }

    public void KillPlayer()
    {
        isPlayerAlive = false;
    }

    public void PlayWalkSound(float HoriInput)
    {
        if(Mathf.Abs(HoriInput) > 0 && _groundCheck.isGrounded())
        {
            SoundManagerScript.Instance.PlayRunSound();
        }
        else
        {
            SoundManagerScript.Instance.StopRunSound();
        }
    }
}
