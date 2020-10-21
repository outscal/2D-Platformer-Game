using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControll : MonoBehaviour
{
    [SerializeField]private int health=3;
    [SerializeField]private Image[] hearts;
    [SerializeField]private Sprite fullHeart,emtyHeart;
    public GameOverController gameOver;
    public ScoreController scoreController;
    [SerializeField]
    private float fast=6f;
    Rigidbody2D rigidbody;
    string ver="Vertical";
    string h="Horizontal";
    BoxCollider2D collider2D;
    public Animator animator;
    float Horizontalspeed;
    private float jump=14f;
    private bool IsPlayerDead;
    int i;
    int numberOfHeart=2;
    bool IsGrounded;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;
    private void Awake(){
            rigidbody=GetComponent<Rigidbody2D>();
            collider2D=GetComponent<BoxCollider2D>();
            
    }
     internal void KillPlayer()
    {
        health--; 
       for(i=numberOfHeart-health;i<=numberOfHeart-health;i++){
                   Destroy( hearts[i]);
       }
        if(health==0){
        animator.SetBool("IsDead",true);
        StartCoroutine(Wait());
        this.enabled=false;
    }
           }
       
    IEnumerator Wait(){
        yield return new WaitForSeconds (1);
       gameOver.PlayerDied();
    }
    internal void PickKey()
    {
        
        scoreController.IncreaseScore(10);
    }

    private void Update(){
      
    Horizontalspeed=Input.GetAxisRaw(h);
    PlayerAnimation(Horizontalspeed);
    PlayerMovementX(Horizontalspeed);
    IsGrounded=Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
    Jump();
    

}
private void PlayerAnimation(float horizontal){
    
       animator.SetFloat("speed",Mathf.Abs(horizontal));
    //     //speed=9.0f;
       Vector3 scale =transform.localScale;
         if (horizontal<0){
            
             scale.x=-1f*Mathf.Abs(scale.x);
         }else if(horizontal>0){
             scale.x=Mathf.Abs(scale.x);
         }
         transform.localScale=scale;
      
}
private void Jump(){
        
        float vericalSpeed=Input.GetAxisRaw(ver);
        if(vericalSpeed>0 && IsGrounded==true){
        animator.SetBool("IsJump",true);
         rigidbody.AddForce(Vector2.up*jump,ForceMode2D.Force);
        }
        else
             animator.SetBool("IsJump",false);
    }
private void PlayerMovementX(float Horizontalspeed){
    Vector2 positionX=transform.position;
    positionX.x=positionX.x+Horizontalspeed*fast*Time.deltaTime;
    transform.position=positionX;
    
}
 
}