using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Animator animator;
     public float speed;
   
    
    
   
    

   
    void Update()
    {
        float vertical = Input.GetAxisRaw("Jump");
        float horizontal = Input.GetAxisRaw("Horizontal");
        Debug.Log("speed= " + horizontal);

        MoveCharacter(horizontal);
        PlayerMovementAnimation(horizontal);
       


        if(Input.GetButtonDown("Fire1")){
            GetComponent<Animator>().Play("Player_Crouch");
        }

    
        if(Input.GetKeyDown(KeyCode.W)){
            animator.SetBool("Jump",true);
        }
    }
    
    private void MoveCharacter(float horizontal){

        Vector3 position=transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position =  position;
    }

    private void PlayerMovementAnimation(float horizontal){

       
       animator.SetInteger("Speed",(int)horizontal);

        

       Vector3 scale = transform.localScale;
        if  (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }

        else if ( horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
       
        transform.localScale = scale;
    }
}
