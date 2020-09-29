﻿using UnityEngine;

public class PlayerControll : MonoBehaviour
{
   // float sf=0.25f;
    private float fast=4f;
    Rigidbody2D rigidbody;
    BoxCollider2D collider2D;
    public Animator animator;
    float Horizontalspeed;
    private float jump=18f;
       private void Awake(){
            rigidbody=GetComponent<Rigidbody2D>();
            collider2D=GetComponent<BoxCollider2D>();
    }
    private void Update(){
      
    Horizontalspeed=Input.GetAxisRaw("Horizontal");
    PlayerAnimation(Horizontalspeed);
   
      PlayerMovementX(Horizontalspeed);
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
        float vericalSpeed=Input.GetAxisRaw("Vertical");
        bool v = Input.GetKeyDown(KeyCode.W);
        bool v2=Input.GetKeyDown(KeyCode.S);
        if(vericalSpeed>0 ){
        animator.SetBool("IsJump",true);
        }
        else if(v2==true){
        animator.SetBool("IsJump",v2);
        }
        else
             animator.SetBool("IsJump",false);
        if(vericalSpeed>0){
            rigidbody.AddForce(new Vector2(0f,jump),ForceMode2D.Force);
        }
}
private void PlayerMovementX(float Horizontalspeed){
    Vector2 positionX=transform.position;
    positionX.x=positionX.x+Horizontalspeed*fast*Time.deltaTime;
    transform.position=positionX;
    
}
 
}