using System.Collections;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float jumpSpeed;
    public float doubleJumpSpeed;
    public float moveSpeed;
    public int keysCollected = 0;
    private Rigidbody2D rigidbody;
    private BoxCollider2D collider;
    private Vector2 spawnPosition;

    public ScoreController scoreController;
    public HealthController healthController;
    public UIManager uiManager;
    private int groundLayer = 9;
    private int alienBlockLayer = 12;
    private int deathColliderLayer = 13;
    private int killerSpikesLayer = 16;
    private int pressurePad = 17;
    private int movingPlatform = 20;

    private bool IsOnGround;
    private bool canDoubleJump;
    private bool isPlayerDead = false;
    private bool isOnMovingGround = false;
    private int lives = 3;

    public float onMovingPlatformspeed;

    private Vector2 startingColliderSize;
    private Vector2 startingColliderOffset;
    private Vector2 newColliderSize = new Vector2(1.0f, 1.4f);
    private Vector2 newColliderOffset = new Vector2(-0.2f, 0.62f);

    private void Awake()
    {

        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        collider = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        startingColliderSize = collider.size;
        startingColliderOffset = collider.offset;
        spawnPosition = transform.position;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if(!isPlayerDead)
        {
            Move(horizontal);
            Jump();
            Crouch();
        }
        
       
    }

    


    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && (IsOnGround || isOnMovingGround))
        {
            animator.SetBool("Jump", true);
            SoundManager.Instance.Play(Sounds.PlayerJump);
            rigidbody.velocity = Vector2.up * jumpSpeed;

        }

        else if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
        {
            animator.SetBool("Jump", true);
            rigidbody.velocity = Vector2.up * doubleJumpSpeed;
            canDoubleJump = false;
        }

       
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void Move(float horizontal)
    {
        Vector2 position = transform.position;
        position.x += horizontal * moveSpeed * Time.deltaTime;
        transform.position = position;

        if(IsOnGround)
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
        
        

        Vector2 scale = transform.localScale;

        if (horizontal < 0 || Input.GetKeyDown(KeyCode.LeftArrow))   // left arrow is used to change its direction
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            
            if(IsOnGround && !animator.GetBool("Crouch"))
            {
                SoundManager.Instance.Play(Sounds.PlayerMovement);
            }
                
            
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);

            if(IsOnGround && !animator.GetBool("Crouch"))
            {
                SoundManager.Instance.Play(Sounds.PlayerMovement);
            }
                

        }

        transform.localScale = scale;
    }


    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
            collider.size = newColliderSize;
            collider.offset = newColliderOffset;

        }

        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
            collider.size = startingColliderSize;
            collider.offset = startingColliderOffset;
        }
    }



    public void PickUpKey()
    {
        keysCollected += 1;
        scoreController.AddScore(10);
    }



    public void PlayerDied()
    {
        isPlayerDead = true;
        SoundManager.Instance.Play(Sounds.PlayerHurt);
        lives--;
        healthController.DecrementLives();
        
        if (lives > 0)
        {
    
            animator.SetBool("Died", true);
            StartCoroutine(SpawmAtSpawnPosition());

        }
        else
        {
            SoundManager.Instance.Play(Sounds.PlayerDeath);
            StartCoroutine(RestartLevel());
            animator.SetBool("Died", true);
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
        
        
    }


    IEnumerator SpawmAtSpawnPosition()
    {
        yield return new WaitForSeconds(2);
        
        transform.position = spawnPosition;
        animator.SetBool("Died", false);
        isPlayerDead = false;
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2);
        uiManager.AwakeGameOverPanel();
    }



    private void OnCollisionEnter2D(Collision2D other)          
    {
        if(other.gameObject.layer == groundLayer || other.gameObject.layer == alienBlockLayer)
        {
            IsOnGround = true;
            canDoubleJump = true;
            
        }

        if (other.gameObject.GetComponent<MovingMuzzles>() != null)
        {
            if(!animator.GetBool("Died"))
            {
                PlayerDied();
            }
        }

        if(other.gameObject.layer == movingPlatform)
        {
            canDoubleJump = true;
            isOnMovingGround = true;
            transform.parent = other.transform;
        }

        if(other.gameObject.layer == killerSpikesLayer)
        {
            PlayerDied();
        }

        if(other.gameObject.layer == pressurePad)
        {
            rigidbody.velocity = Vector2.up * 60;
            animator.SetBool("Jump", true);
        }

        if (other.gameObject.layer == deathColliderLayer)
        {
            PlayerDied();
        }


    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.layer == groundLayer || other.gameObject.layer == alienBlockLayer)
        {
            IsOnGround = false;
        }
        if(other.gameObject.layer == movingPlatform)
        {
            isOnMovingGround =
            transform.parent = null;
        }
    }

}
