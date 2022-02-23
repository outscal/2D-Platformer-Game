using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] public float MoveSpeed,JumpForce,Runspeed;
    private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        
        //Adding Movement To Our Player
        Move();
         
        //Adding Jump To Our Player
        if(Input.GetKeyDown(KeyCode.Space) ) {
        rb.AddForce(new Vector2(0,JumpForce),ForceMode2D.Impulse);
        SetJumpAnimation();
        }
        
        //Adding Crouch To Player
        if(Input.GetKeyDown(KeyCode.C)) {
        SetCrouchAnimation();
        }

    }

    void SetJumpAnimation() { 
            anim.SetTrigger("isJump");
    }

    void SetCrouchAnimation() {
            anim.SetTrigger("isCrouch");       
    }

    private void Move() {
        
        //Setting Up The Movement In Horizontal Direction
        var movement = Input.GetAxisRaw("Horizontal");   
        
        //Changing Player Position According to Movement
        transform.position += new Vector3(movement,0,0) * Time.deltaTime * MoveSpeed;
        
        //Left Movement 
        if(Input.GetKey(KeyCode.D) && movement > 0) {

             MoveSpeed = Runspeed;
             Vector3 temp = transform.localScale;
             temp.x = 1f;
             transform.localScale = temp;
             anim.SetBool("isRun",true);
        }
        
        
        //Right Movement
        else if( movement < 0 && Input.GetKey(KeyCode.A) ) {

            MoveSpeed = Runspeed;
            Vector3 temp = transform.localScale;
            temp.x = -1f;
            transform.localScale = temp;
            anim.SetBool("isRun",true);
        }
        
        //if No key Pressed Go Back To Idle Animation
        else {
            anim.SetBool("isRun",false);
            }
    }
            

}
