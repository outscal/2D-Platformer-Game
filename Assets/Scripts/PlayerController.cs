using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
   
    void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        //Debug.Log(inputHorizontal);
        animator.SetFloat("Speed", Mathf.Abs(inputHorizontal));
        Vector3 scale = transform.localScale;
        if (inputHorizontal > 0)
        {
            animator.SetBool("isRunning", true);
            transform.localScale = new Vector3(Mathf.Abs(scale.x), scale.y, scale.z);
        }
        else if (inputHorizontal < 0)
        {
            animator.SetBool("isRunning", true);
            transform.localScale = new Vector3(-1 * Mathf.Abs(scale.x), scale.y, scale.z);
        }
        else {
            animator.SetBool("isRunning", false);
        }
    }
}
