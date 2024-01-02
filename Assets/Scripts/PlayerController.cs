using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed",Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if(speed < 0){
            scale.x = -1f * Mathf.Abs(scale.x);
        }else if(speed > 0){
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
         float speedV = Input.GetAxisRaw("Vertical");
         if(Input.GetKeyDown(KeyCode.UpArrow)){
           animator.SetBool("jump",true);
         }else if(Input.GetKeyUp(KeyCode.UpArrow)){
            animator.SetBool("jump",false);
         }
          
         if(Input.GetKeyDown(KeyCode.RightControl)){
            animator.SetBool("crouch",true);
         }else if(Input.GetKeyUp(KeyCode.RightControl)){
            animator.SetBool("crouch", false);
         }
        
       
        
    }
    
}
