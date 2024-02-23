using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)
        {           
            Animator.SetBool("IsMoving",true);
            Vector3 Scale = transform.localScale;
            Scale.x = Mathf.Abs(Scale.x);
            transform.localScale = Scale;
        }
        else if(Input.GetAxisRaw("Horizontal")<0)
        {
            Animator.SetBool("IsMoving", true);
            Vector3 Scale = transform.localScale;
            Scale.x = -1f * Mathf.Abs(Scale.x);
            transform.localScale = Scale;
        }
        else if(Input.GetAxisRaw("Vertical")>0)
        {
            Animator.SetBool("IsJumping", true);
        }
        else if(Input.GetKey(KeyCode.C))
        {            
            Animator.SetBool("IsCrounched",true);
        }
        else
        {
            Animator.SetBool("IsMoving",false);
            Animator.SetBool("IsCrounched", false);
            Animator.SetBool("IsJumping", false);
        }
    }
}
