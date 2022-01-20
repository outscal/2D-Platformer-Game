using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed = 5; 
    public float jumpVertical;  
    private Rigidbody2D rbd2d; 

    public bool isGrounded = false;

    private void Awake(){ 
        rbd2d = gameObject.GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");  
        float vertical = Input.GetAxisRaw("Jump");
        bool crouch = Input.GetKeyDown(KeyCode.LeftControl);
        
        MoveCharacter(horizontal, vertical); 
        PlayerMovementAnimation(horizontal); 
        playerJumpAnimation(vertical);
        PlayerCrouchAnimation(crouch);
    }

    private void MoveCharacter(float horizontal, float vertical){
        Vector3 position = transform.position;
        //(distance / time)  * (1 / frames per second) 
        position.x += horizontal * speed * Time.deltaTime;       
        transform.position = position;         

        if(vertical > 0 && isGrounded == true){
            rbd2d.AddForce(new Vector2(0,jumpVertical), ForceMode2D.Force);
        }
    }

    private void PlayerMovementAnimation(float horizontal)
    {   
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;

        if(horizontal < 0){
            scale.x = -1f * Mathf.Abs(scale.x);
        } else if(horizontal > 0){
            scale.x = Mathf.Abs(scale.x);
        }         
        transform.localScale = scale;
        
    }

    private void playerJumpAnimation(float vertical)
    {
        if(vertical > 0)
        {
            animator.SetBool("Jump", true);
        } else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void PlayerCrouchAnimation(bool crouch)
    {
        if(crouch)
        {
            animator.SetBool("Crouch", true);
        } else
        {
            animator.SetBool("Crouch", false);
        }

    }
}
