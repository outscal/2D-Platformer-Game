using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    
    // Start is called before the first frame update
    private  void Update()
    {
        float speed=Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed",Mathf.Abs(speed));
        // for run in flip
        
        Vector3 scale=transform.localScale;
        if(speed<0){
            scale.x=-1f*Mathf.Abs(scale.x);
        }else if(speed>0){
            scale.x=Mathf.Abs(scale.x);
        }
        transform.localScale=scale;
        
        bool isCrouching= Input.GetKey(KeyCode.DownArrow);
        animator.SetBool("Crouch",isCrouching);
        
        bool jump=Input.GetKey(KeyCode.UpArrow);
        // animator.SetFloat("Speed",Mathf.Abs(speed1));
        animator.SetBool("Jump",jump);
           
    }

}
