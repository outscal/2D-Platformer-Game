using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
     public Animator Animator;
    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        Animator.SetFloat("Speed", Mathf.Abs(speed));

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Animator.SetBool("IsJumping", true);
        //    Animator.SetBool("IsJumping", false);

        //}
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    Animator.SetBool("IsCrouching", true);
        //    Animator.SetBool("IsCrouching", false);

        //}

        Vector3 scale = transform.localScale;
        if (speed<0) // pressed A/ right arrow 
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(speed > 0)  // pressed D/left arrow
        {
            scale.x = Mathf.Abs(scale.x);
        }
            transform.localScale = scale;
    }
}
