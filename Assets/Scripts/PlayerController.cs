using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    private void Awake ()
    {
        Debug.Log("awake");
    }
    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed",Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if(speed <0)
        { 
            // bool jump = Input.GetButton("Vertical");
            // animator.SetBool("Jump",jump);

            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            //  bool jump = Input.GetButton("Vertical");
            // animator.SetBool("Jump",jump);
            scale.x = Mathf.Abs(scale.x);   
        }
        transform.localScale =scale;
        
       bool jump = Input.GetButton("Vertical");
            animator.SetBool("Jump",jump);

        bool crouch = Input.GetKey(KeyCode.LeftControl);
        animator.SetBool("Crouch",crouch);
        
    }
}
