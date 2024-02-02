using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator animator;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horispeed = Input.GetAxisRaw("Horizontal");
        float vertispeed = Input.GetAxisRaw("Vertical");
        if (horispeed < 0)
        {
            spriteRenderer.flipX = true;           
                     
        }
        if(horispeed > 0)
        {
            spriteRenderer.flipX = false;           
                    
        } 
        animator.SetFloat("Speed", horispeed);               
        if (vertispeed>0 )
        {
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsCrouching", false);
        }
        if(vertispeed == 0)
        {
            animator.SetBool("IsCrouching", false);
            animator.SetBool("IsJumping", false);
        }
        if(vertispeed<0 )
        {           
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsCrouching", true);
        }
        animator.SetFloat("VSpeed", vertispeed);
    }

    
}
