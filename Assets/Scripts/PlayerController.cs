using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public GameOverController gameOverController;
    private int numOfHearts=3;
    public Image[] hearts;
    public ScoreController scoreController;
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D rb;
    private Collider2D collision;
    
    // Update is called once per frame
    private void Awake(){
        rb=gameObject.GetComponent<Rigidbody2D>();
    }
    private void start(){
        
    }
    
    void Update()
    {
       float horizontal= Input.GetAxisRaw("Horizontal");
       float vertical= Input.GetAxisRaw("Vertical");
       playAnimationMovement(horizontal,vertical); 
       moveCharacter(horizontal,vertical);
       playerDeath();
       playerHealth();
    }
    
    public void pickUpKey(){
        scoreController.IncreaseScore(10);
    }
    
    public void KillPlayer(){
        
        animator.SetTrigger("Death");
        numOfHearts-=1;  
        if(numOfHearts==0){
            gameOverController.PlayerDied();
        }
    }
    
    
    public void playerHealth()
    {   
        for (int i=0;i<hearts.Length;i++){
            if(i<numOfHearts){
                hearts[i].enabled=true;
            }else{
                hearts[i].enabled=false;
            }
        }
    }
    
    private void playerDeath(){
        Vector3 position =transform.position;
        if(position.y<(-5f)||position.y>(15f)){
            animator.SetTrigger("Death");
            gameOverController.ReloadLevel();
            numOfHearts-=1; 
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
        
        // Flipping
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
        }
        // jumping animation
        
        if(vertical>0){    
            animator.SetBool("Jump",true);
        }else{
            animator.SetBool("Jump",false);
        }
    }
}
