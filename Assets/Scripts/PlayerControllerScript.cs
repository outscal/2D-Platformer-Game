using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public Animator animator; 

    public float speed;

    // Update is called once per frame
    void Update()
    {
       float  hrzntl = Input.GetAxisRaw("Horizontal");
       float  vrtcl = Input.GetAxisRaw("Vertical");

       PlayerAnimationBinding(hrzntl,vrtcl);
       MoveCharacter(hrzntl);

    }
     private void MoveCharacter(float horizontal)
     {
       Vector3 position = transform.position;
       position.x = position.x + horizontal * speed* Time.deltaTime;
       transform.position = position;
     }

     private void PlayerAnimationBinding(float horizontal, float vertical)
    {
         animator.SetFloat("Speed",Mathf.Abs(horizontal));

       Vector3 resize = transform.localScale;
       if(horizontal < 0)
       {
        resize.x = -1f * Mathf.Abs(resize.x);
       }
       else if(horizontal > 0)
       {
        resize.x = Mathf.Abs(resize.x);
       }
       transform.localScale = resize;

//crouch
       bool crouch = Input.GetKey("left ctrl");
       animator.SetBool("Crouch",crouch);

//jump
       if(vertical > 0)
       {
        animator.SetFloat("Jump", Mathf.Abs(vertical));
       }
   
    }
    
};    