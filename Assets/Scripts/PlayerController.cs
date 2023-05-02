using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    private bool crouch = false;
    private bool jump = false;
    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Speed", Mathf.Abs(speed));

        //Jump Logic
        if(vertical > 0 )
        {
            jump= true;
        }
        else
        {
            jump= false;
        }
        anim.SetBool("Jump", jump);
        //Crouch logic
        if (Input.GetKey(KeyCode.LeftControl))
        {
            crouch = true;
        }
        else
        {
            crouch = false;
        }
        anim.SetBool("Crouch", crouch);

        //Running logic
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {   
            scale.x = -1f * Mathf.Abs(speed);
        }
        else if(speed > 0)
        {
            scale.x = Mathf.Abs(speed);
        }
        transform.localScale = scale;
    }
}
