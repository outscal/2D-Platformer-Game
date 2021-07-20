using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Update is called once per frame

    //this enables us to add GameObject/Prefab to the Script
    public Animator animator;

    

    private void Update()
    {

        float speed = Input.GetAxisRaw("Horizontal");
        PlayCrouchAnimation();
        PlayJumpAnimation();
        PlayHorizontalAnimation(speed);
    }

    private void PlayCrouchAnimation()
    {
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        if (crouch == true)
        {
            animator.SetBool("Crouch", true);
        }
        else
        {
            animator.SetBool("Crouch", false);
        }
    }

    private void PlayJumpAnimation()
    {
        bool jump = Input.GetKey(KeyCode.Space);
        if (jump == true)
        {
            animator.SetBool("Jump", true);
            //transform.Translate(Vector3.up * 3 * Time.deltaTime, Space.World);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void PlayHorizontalAnimation(float speed)
    {
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
        
       

    
}
