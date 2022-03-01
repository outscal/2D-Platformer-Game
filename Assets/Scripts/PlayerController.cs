using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    void Start()
    { 
            
    }


    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxisRaw("Vertical");
        PlayerAnimation(speed, jump);
    }
        
        private void PlayerAnimation(float speed, float jump)
        { 
        animator.SetFloat("Speed",Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
          scale.x = -1f * Mathf.Abs(scale.x);
        }else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        
        if (jump > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
         

   if(Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
         }
    else
        {
    animator.SetBool("Crouch", false);
        }
    }




}
