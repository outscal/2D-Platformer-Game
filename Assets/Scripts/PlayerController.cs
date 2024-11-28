using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed",Mathf.Abs (speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
           
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {

            scale.x = Mathf.Abs (scale.x);
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
        if(vertical>0)
        {
            animator.SetTrigger("Jump");
        }


     

        




    }
    

}

