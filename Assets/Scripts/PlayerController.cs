using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
[SerializeField] Animator animator;

private void Update()
    { 
float sp = Input.GetAxisRaw("Horizontal");
float jump = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(sp));

Vector3 scale = transform.localScale;

if(sp<0) {
            scale.x = -1f * Mathf.Abs(scale.x);
} else if (sp > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
//for crouch
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        else
        {
            animator.SetBool("Crouch", false);
        }

        //for jump
        if (jump > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }


        transform.localScale = scale;
}
}
