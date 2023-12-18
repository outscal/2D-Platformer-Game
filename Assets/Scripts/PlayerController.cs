using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] float horizontalInput;

    bool flip;

    private void Start()
    {
        animator = GetComponent<Animator>();
        flip = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        animator.SetBool("IsRunning", false);


        if (horizontalInput != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        if (horizontalInput < 0)
        {
            flip = true;
        }
        else if (horizontalInput > 0)
        {
            flip = false;
        }

       /* if (Mathf.Approximately(horizontalInput, 0f))
        {
            flip = false;
        }*/

        GetComponent<SpriteRenderer>().flipX = flip;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool("IsCrouching", true);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetBool("IsCrouching", false);
        }
    }
}
