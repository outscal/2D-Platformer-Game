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
            animator.SetBool("IsJumping", false);
        }
        if(horispeed > 0)
        {
            spriteRenderer.flipX = false; 
            animator.SetBool("IsJumping", false);
        }
        animator.SetFloat("Speed", horispeed);
        
        if (vertispeed>0)
        {
            animator.SetBool("IsJumping", true);
           
        }
        if(vertispeed < 0)
        {
            animator.SetBool("IsJumping", false);
        }
    }
}
