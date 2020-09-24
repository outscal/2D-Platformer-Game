using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    
    public Animator Animator;
    public BoxCollider2D boxCollider;

    private float OriginalSizeCollider;
    private float Valuex;
    public float crouchHeight;
    private float resize;
    private bool IsCrouching=false;
    // Start is called before the first frame update
    void Start()
    {
       boxCollider = GetComponent<BoxCollider2D>(); 

       OriginalSizeCollider = boxCollider.size.y;
       Valuex = boxCollider.size.x;
       Debug.Log(OriginalSizeCollider);
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        Animator.SetFloat("Speed", Mathf.Abs(speed));
        ChangeDirection(speed);
        // float jumpingspeed = Input.GetAxisRaw("Vertical");
        //  int isjumping = 1;
        // if(jumpingspeed>0 ){
           
        //      Jump(isjumping);
        // }
       
       //now Code for Crouching our Player


        Crouch();
       
    }

    //Packed all the code in one place to change the direction of Player
    void ChangeDirection(float speed){
         Vector3 scale = transform.localScale; 
        if(speed < 0){   
            scale.x = - 1 * Mathf.Abs(scale.x);
            Debug.Log(speed);
        } else if(speed > 0){
               scale.x = Mathf.Abs(scale.x); 
               Debug.Log(speed);
        }
        transform.localScale = scale;
    }

    void Crouch(){
        if(Input.GetKey(KeyCode.LeftControl)){
            if(IsCrouching==false){
                IsCrouching= true;
                Animator.SetTrigger("IsCrouch");
             //Animator.SetBool("IsCrouch",true);
             resize = crouchHeight;
             boxCollider.size = new Vector2(Valuex,resize);  
            }else{
                 IsCrouching= false;
                    Animator.ResetTrigger("IsCrouch");
           //      Animator.SetBool("IsCrouch",false);
                 boxCollider.size = new Vector2(Valuex,OriginalSizeCollider); 
            }
        }
    }

   
}
