using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public Animator animator;
    private void Awake() 
    {
        Debug.Log("Player Controller awake");
    }
    public void Update()
    {
        Movement();
    }
    void Movement()
    {
        float speed  = (Input.GetAxisRaw("Horizontal") );
        bool jump = Input.GetKey(KeyCode.Space);
        animator.SetFloat("Speed", Mathf.Abs(speed));

        Vector3 scale = transform.localScale;
        if(speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            
        }
        transform.localScale = scale;

        // bool jump = Input.GetKey(KeyCode.Space);
        // animator.SetBool("Jump", Mathf.Abs(jump));


    }
}
