﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    float sf=0.25f;
    Rigidbody2D rigidbody;
    BoxCollider2D collider2D;
    public Animator animator;
    private void Awake(){
        Debug.Log("Player controller");
    }
    private void OnCollisionEnter(Collision collision)

    {
        
        //Debug.Log("collision:"+collision.gameObject.name);
        if (collision is null)
        {
            throw new System.ArgumentNullException(nameof(collision));
        }
       
    }
    private void Start(){
            rigidbody=GetComponent<Rigidbody2D>();
            collider2D=GetComponent<BoxCollider2D>();
    }
    private void Update(){
      
     float speed=Input.GetAxisRaw("Horizontal");
     if(Input.GetKeyDown(KeyCode.LeftControl)){
         sf=2.0f;
         }
         else
         sf=0.0f;
     //speed=speed*sf; 
     animator.SetFloat("speed",Mathf.Abs(speed));
    //     //speed=9.0f;
 
    //    // animator.SetFloat("jump",Mathf.Abs(jump));
       
       Vector3 scale =transform.localScale;
         if (speed<0){
            
             scale.x=-1f*Mathf.Abs(scale.x);
         }else if(speed>0){
             scale.x=Mathf.Abs(scale.x);
         }
         transform.localScale=scale;
         float jmp=Input.GetAxisRaw("Vertical");
        bool v = Input.GetKeyDown(KeyCode.W);
        if(v==true)
        animator.SetBool("IsJump",v);
        else
        animator.SetBool("IsJump",false);
        float X=0.55462f;
        float Y=2.2113f;
      collider2D.size=new Vector2(X,collider2D.size.x);
      collider2D.size=new Vector2(Y,collider2D.size.y);

    
}

  
}