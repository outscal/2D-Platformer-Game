using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrolnew : MonoBehaviour
{
    public Animator animator;
   
    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;

        if (speed < 0)
        {
            scale.x = -1 * Mathf.Abs(speed);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(speed);
        }
        transform.localScale = scale;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
        }

        float vertical = Input.GetAxisRaw("Jump");

        if (vertical>0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

}