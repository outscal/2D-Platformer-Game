using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    
    // Update is called once per frame
    void Update()
    {
       float horizontal= Input.GetAxisRaw("Horizontal");
       playAnimationMovement(horizontal); 
       moveCharacter(horizontal);
    }
    private void moveCharacter(float horizontal){
        Vector3 position =transform.position;
        position.x +=horizontal*speed*Time.deltaTime;
        transform.position=position;
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
        
        bool crouch=Input.GetKey(KeyCode.Space);
        animator.SetBool("Crouch",crouch);
        
        // jumping
        bool jump=Input.GetKey(KeyCode.UpArrow);
            animator.SetBool("Jump",jump);
        
    }
}
