using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator Animator;

    private void Update ()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        Animations(speed, vertical);
    }

    private void Movement () 
    {

    }

    private void Animations (float speed, float vertical) 
    {
        Animator.SetFloat("Speed", Mathf.Abs(speed));

        Vector3 scale = transform.localScale;

        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        if (Input.GetKeyDown("space"))
        {
            Animator.SetBool("Jumped", true);
        }
        else
        {
            Animator.SetBool("Jumped", false);
        }

        transform.localScale = scale;

        if (Input.GetKeyDown("left ctrl") || Input.GetKeyDown("right ctrl"))
        {
            Animator.SetTrigger("someTrigger");
            Animator.ResetTrigger("otherTrigger");
            Animator.SetBool("Crouched", true);
        }
        else if (Input.GetKeyUp("left ctrl") || Input.GetKeyUp("right ctrl"))
        {
            Animator.SetTrigger("otherTrigger");
            Animator.ResetTrigger("someTrigger");
            Animator.SetBool("Crouched", false);
        }
    }
}
