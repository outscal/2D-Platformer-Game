using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
       float horizontal= Input.GetAxisRaw("Horizontal");
       playAnimationMovement(horizontal); 
    }
    private void playAnimationMovement(float horizontal){
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
    }
}
