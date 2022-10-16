using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rgbd2d;

    private BoxCollider2D boxCollider2D;
    public float xspeed;
    public float jumpVal;
    bool isGrounded;

    float offsetX;
    float offsetY;
    float sizeX;
    float sizeY;

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
        float speed = Input.GetAxisRaw("Horizontal");
        //Jump
        float jumpinput = Input.GetAxisRaw("Jump");

        PlayerMovement(speed,jumpinput);
        PlayerMoveAnimation(speed,jumpinput);
        
        //crouch
       
    }
    //Player Move left and right 
    private void PlayerMovement(float speed, float jumpinput)
    {   //move Player Horizontally
        Vector3 position = transform.position;
        position.x += speed * xspeed * Time.deltaTime;
        transform.position = position;
        
        // move player vertically
        if(jumpinput > 0 )
        {
            rgbd2d.AddForce(new Vector2(0f,jumpVal),ForceMode2D.Force);
        }
    
    }
    //player flipped left or right animation 
    private void PlayerMoveAnimation(float speed,float jumpinput)
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
    // private void OnColliderStay2D(Collider2D col)
    // {
    //     if(col.gameObject.tag == "Platform")
    //     {
    //         isGrounded = true;
    //     }
    // }
    // private void OnColliderExit2D(Collider2D col)
    // {
    //     if(col.gameObject.tag == "Platform")
    //     {
    //          isGrounded = false;
    //     }
    // }
    
}
