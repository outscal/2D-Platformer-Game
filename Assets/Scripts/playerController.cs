using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
     public Animator Animator;
    [SerializeField]
    float Jump_Power;

    void PlayingAnimation() {
        float speed = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxisRaw("Vertical");
        Animator.SetFloat("Speed", Mathf.Abs(speed));

        if (jump > 0 || Input.GetKeyDown(KeyCode.Space))
        {
            Animator.SetBool("IsJumping", true);
            //Jumping();
        }
        if (jump < 0 || Input.GetKeyDown(KeyCode.LeftControl))
        {
            Animator.SetBool("IsCrouching", true);
        }

        Vector3 scale = transform.localScale;
        if (speed < 0) // pressed A/ right arrow 
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)  // pressed D/left arrow
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
    void Jumping()
    {
        Vector3 jumping = transform.position;
        jumping.y += Jump_Power;
        transform.position = jumping;
    }
    void StopJumpAnim()
    {
        Animator.SetBool("IsJumping", false);
    }
    void StopCrouchAnim()
    {
        Animator.SetBool("IsCrouching", false);
    }

    private void Update()
    {
        PlayingAnimation();
    }
}

        
