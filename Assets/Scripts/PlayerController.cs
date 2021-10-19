using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D rb;
    
    // Update is called once per frame
    private void Awake(){
        rb=gameObject.GetComponent<Rigidbody2D>();
    }
    public void pickUpKey(){
         Debug.Log("Player pick the key");
         scoreController.IncreaseScore(10);
    }
    public void KillPlayer(){
         Debug.Log("Player Killed by Enemy");
        //  play player death animation
    }
    void Update()
    {
       float horizontal= Input.GetAxisRaw("Horizontal");
       float vertical= Input.GetAxisRaw("Vertical");
       playAnimationMovement(horizontal,vertical); 
       moveCharacter(horizontal,vertical);

       playerDeath();
    }
    private void playerDeath(){
        Vector3 position =transform.position;
        if(position.y<(-5f)||position.y>(15f)){
            Debug.Log("Player is death");
        }
    }
    private void moveCharacter(float horizontal,float vertical){
        // Movement 
        Vector3 position =transform.position;
        position.x +=horizontal*speed*Time.deltaTime;
        transform.position=position;
        // jump
        if (vertical>0){
            rb.AddForce(new Vector2(0f,jump),ForceMode2D.Impulse);
        }
    }
    private void playAnimationMovement(float horizontal,float vertical){
        animator.SetFloat("Speed",Mathf.Abs(horizontal));
        
        // Flipping Animation
        Vector3 scale=transform.localScale;
        if(horizontal<0){
            scale.x=-1f*Mathf.Abs(scale.x);
        }
        if(horizontal>0){
            scale.x=Mathf.Abs(scale.x);
        }
        transform.localScale=scale;
        
        //crouch animation
        if(Input.GetKey(KeyCode.Space)){
            animator.SetBool("Crouch",true);
        }else{
            animator.SetBool("Crouch",false);
        }
        
        // jumping animation
        if(vertical>0){    
            animator.SetBool("Jump",true);
        }else{
            animator.SetBool("Jump",false);
        }
    }
}
