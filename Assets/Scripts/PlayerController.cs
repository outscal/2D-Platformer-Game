using System.Diagnostics;
using System.Collections;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
    {

    public Animator animator;
  

    // Start is called before the first frame update
    private void Awake()
    {
       
    }
    void Start()
    {
        print("Game Start");
        //Debug.Log("Game Start");
    }

    // Update is called once per frame
    void Update()
    {

        float run = Input.GetAxisRaw("Horizontal"); // -1 to 1 0
        animator.SetFloat("speed", Mathf.Abs(run));

        float vertical = Input.GetAxisRaw("Jump");
        //crouch
        bool crouchVertical = Input.GetKey(KeyCode.LeftControl);

        MovementAnimation(run, vertical, crouchVertical);
       
    }

    private void MovementAnimation(float run, float vertical, bool crouchVertical)
    {

        //Run Animation
        Vector3 scale = transform.localScale;
        // scale = x=2.0f, y=2.0f,z=1.0f
        // scale =(2.0f,2.0f,1.0f);
        if (run < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            //scale=(scale.x,2.0f,1.0f);
            transform.localScale = scale; //transform.localScale=(scale.x,2.0f,1.0f);
        }

        else if (run > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale; //transform.localScale=(scale.x,2.0f,1.0f);
        }

        //Jump Animation
        if (vertical > 0)
        {
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }

        //crouch Animation

        if (crouchVertical == true)
        {
            animator.SetBool("crouch", true);

        }
        else
        {
            animator.SetBool("crouch",false);
        }

        
    }

    
}
