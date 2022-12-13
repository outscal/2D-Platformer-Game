using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;

    
    [SerializeField] private GameManager gameManager;
     [SerializeField]private PlayerDeath playerDeath;
    public Animator animator;
    private Rigidbody2D rgbd2d;

    private BoxCollider2D boxCollider2D;
    [SerializeField] float xspeed;
    [SerializeField] float jumpVal;
    [SerializeField] private LayerMask jumpableGround;
    
    
    [SerializeField]int playerHealth;
     public ParticleSystem DustCloud;
     public ParticleSystem Spawner;
    [SerializeField] private float JumpForce = 10f;

    
    float speed;
    float jumpinput;
    private bool DoubleJump;

    private void Awake ()
    {
        Debug.Log("awake");
        
    }
    private void Start ()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rgbd2d = gameObject.GetComponent<Rigidbody2D>();
        
    }
   
    private void Update()
    {   //movement animation and Player move left or right direction.
        speed = Input.GetAxisRaw("Horizontal");
        // Double Jump
        if(isGrounded() && !Input.GetButton("Jump"))
        {
            DoubleJump = false;
        }
        //Jump
        if(jumpinput == 0)
        {
               if(Input.GetButtonDown("Jump"))
               {
                if(isGrounded() || DoubleJump)
                {
                     DustCloudParticle();
                     rgbd2d.velocity = new Vector2(rgbd2d.velocity.x,JumpForce);
                     DoubleJump = !DoubleJump;
                }
               }
      
        }
     

        PlayerMovement();
        PlayerMoveAnimation();
        
        //crouch
       
    }
    //Player Move left and right 
    private void PlayerMovement()
    {   //move Player Horizontally
       
        Vector3 position = transform.position;
        position.x += speed * xspeed * Time.deltaTime;
        transform.position = position;
        
        // move player vertically
       
    
    }
    //player flipped left or right animation 
    private void PlayerMoveAnimation()

    {
        
         animator.SetFloat("Speed",Mathf.Abs(speed));
         
        Vector3 scale = transform.localScale;
        if(speed <0)
        { 
            
           
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
             
            scale.x = Mathf.Abs(scale.x);   
        }
        transform.localScale =scale; 

        //Jump animation
        // if(jumpinput > 0)
        // {
        //     Instantiate(DustCloud, transform.position, Quaternion.identity);
        //     animator.SetBool("Jump", true);
        // }
        // else{
        //      animator.SetBool("Jump", false);
        // }
    if(rgbd2d.velocity.y > .1f)
    {
             //DustCloudParticle();
            animator.SetBool("Jump", true);
    }
    else 
    {
        animator.SetBool("Jump", false);
    }

        //Player Crouching Animations
         if(Input.GetKey(KeyCode.LeftControl))
        {
            CrouchAnim(true);
        }
        else{
            CrouchAnim(false);
        }
       
    }
    
    
    //Player Crouch
    private void CrouchAnim(bool Crouch)
    {
         if (Crouch == true)
        {       //Change the box collider size When player is crouch
                animator.SetBool("Crouch", Crouch);
        }

        else
        {   //when Player not crouching Collider automatically resize
                animator.SetBool("Crouch", Crouch);
        }
        

       
    }
   
    
    public void PickupKey()
    {
        Debug.Log("Key Collect By the Player");
        //collectItem.IncreaseItem(1);
        scoreController.IncreaseScore(10);
      


    }
    // public void EnemyKills()
    // {
    //     Debug.Log("Player Collide with Enemy");
    //     animator.SetTrigger("Death");
    //     RestartLevel();

    // }
    public void HealthSystem()
    {
        playerHealth -= 1;
        gameManager.HealthHearts(playerHealth);
        if(playerHealth > 0)
        {
            animator.SetTrigger("Hurt");
            SoundManager.Instance.Play(Sounds.PlayerHurt);
        }
        CheckHealth();
    }
    public void FallingDown()
    {
        playerHealth -= 10;
        gameManager.HealthHearts(playerHealth);
        CheckHealth();
    }
    public void CheckHealth()
    {
        
       
        if(playerHealth <= 0)
        {
            PlayerDie();
                        
        }
    }
     public void PlayerDie()
    {
        // mainCamera.transform.parent = null;
        // deathUIPanel.gameObject.SetActive(true);
        animator.SetTrigger("Death");
        SoundManager.Instance.Play(Sounds.PlayerDeath);
       this.enabled = false;

        
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {   
        if(collision2D.gameObject.tag == "Enemy")
        {
           HealthSystem();
        }
        if(collision2D.gameObject.tag == "Key")
        {
            scoreController.IncreaseScore(10);
            scoreController.IncreamentKey(1);
        }
        if(collision2D.gameObject.tag == "Spawner")
        {
             Instantiate(Spawner, transform.position, Quaternion.identity);
        }

    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center,boxCollider2D.bounds.size,0f, Vector2.down, 1f,jumpableGround);
    }
    private void DustCloudParticle()
    {
        DustCloud.Play();
    }
//    private void Spawnerpartical( )
//     {
//          Spawner.Play();
//     }
    
       
    

   
}
