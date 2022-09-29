using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    public Animator animator;
    public bool jumpSpeed;

    private void Update()
    {
        float Speed =  Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(Speed));
       
      
            Crouch();
        
        
        
        Vector3 scale = transform.localScale;
        if (Speed < 0)
        { 
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (Speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", true);

        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", false);
        }
    }
}
