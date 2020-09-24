using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    
    public Animator Animator;
   
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        Animator.SetFloat("Speed", Mathf.Abs(speed));
         Vector3 scale = transform.localScale; 
        if(speed < 0){   
            scale.x = - 1 * Mathf.Abs(scale.x);
            Debug.Log(speed);
        } else if(speed > 0){
               scale.x = Mathf.Abs(scale.x); 
               Debug.Log(speed);
        }
        transform.localScale = scale;

        if(Input.GetKeyDown(KeyCode.W)){
            Animator.SetBool("IsJump",true);   
        }
       

        if(Input.GetKeyUp(KeyCode.W)){
           Animator.SetBool("IsJump",false); 
           
        }
        
        // if(Input.GetKey(KeyCode.W)){
        //     Animator.SetBool("IsJump",true);
        //     // jumped=true;
        //     // if(jumped==true){
        //     //     Animator.SetBool("IsJump",false);
        //     //     jumped=false;
        //     // }
        // }
    }
}
