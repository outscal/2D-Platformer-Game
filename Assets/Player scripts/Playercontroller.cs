using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public Animator animator;
    private void Awake()
    {
        Debug.Log("I AM ON");
    }


    private void Update()
    {

        float speed = Input.GetAxisRaw("Horizontal");
         Vector3 scale = transform.localScale;
        animator.SetFloat("Speed",  Mathf.Abs(speed));

        if (speed < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);

        }
        else if (speed > 0) {
        
         scale.x= Mathf.Abs(scale.x);
        }
        transform.localScale = scale;



        if (Input.GetKeyDown(KeyCode.LeftControl)){

            animator.SetBool("iscrouch", true);

        }
        if (Input.GetKeyUp(KeyCode.LeftControl)){


            animator.SetBool("iscrouch", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("jump");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.ResetTrigger("jump");
        }

    }


 


}
