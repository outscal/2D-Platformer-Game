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
    
    bool isGrounded;
    [SerializeField]int playerHealth;

    float offsetX;
    float offsetY;
    float sizeX;
    float sizeY;
    float speed;
    float jumpinput;

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
        //Jump
        jumpinput = Input.GetAxisRaw("Jump");

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
        if(jumpinput > 0 )
        {
            rgbd2d.velocity = new Vector2(0,jumpVal);
        }
    
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
        if(jumpinput > 0)
        {
            animator.SetBool("Jump", true);
        }
        else{
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
            offsetX = -0.08742696f;
            offsetY = 0.6050405f;          

            sizeX = 0.6085089f;               
            sizeY = 1.180404f;               
        }

        else
        {   //when Player not crouching Collider automatically resize
            offsetX = -0.002331734f;
            offsetY = 0.9794595f;           

            sizeX =  0.4383185f;             
            sizeY = 1.929242f;              
        }
        animator.SetBool("Crouch", Crouch);

        boxCollider2D.size = new Vector3(sizeX, sizeY);     //Setting the size of collider
        boxCollider2D.offset = new Vector3(offsetX, offsetY); 
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Platform")
        {
             isGrounded = false;
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
            playerHealth -= 1;
        gameManager.HealthHearts(playerHealth);
        if(playerHealth > 0)
        {
            animator.SetTrigger("Hurt");
        }
        CheckHealth();
        }
        if(collision2D.gameObject.tag == "Key")
        {
            scoreController.IncreaseScore(10);
            scoreController.IncreamentKey(1);
        }

    }

   
}
