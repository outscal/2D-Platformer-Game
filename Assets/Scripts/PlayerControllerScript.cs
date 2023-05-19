using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public Animator animator; 

    // Update is called once per frame
    void Update()
    {
       float  hrzntl = Input.GetAxisRaw("Horizontal");
       float  vrtcl = Input.GetAxisRaw("Vertical");

       animator.SetFloat("Speed",Mathf.Abs(hrzntl));

       Vector3 resize = transform.localScale;
       if(hrzntl < 0)
       {
        resize.x = -1f * Mathf.Abs(resize.x);
       }
       else if(hrzntl > 0)
       {
        resize.x = Mathf.Abs(resize.x);
       }
       transform.localScale = resize;

//crouch
       bool crouch = Input.GetKey("left ctrl");
       animator.SetBool("Crouch",crouch);

//jump
       if(vrtcl > 0)
       {
        animator.SetFloat("Jump", Mathf.Abs(vrtcl));
       }
   
    }
};    