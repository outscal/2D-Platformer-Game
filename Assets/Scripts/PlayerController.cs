using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Update is called once per frame

    //this enables us to add GameObjext/Prefab to the Script
    public Animator animator;
    private void Update()
    {
        //Input.GetAxisRaw fetches whatever is inside the brackets, Horizontal in this case
        //Horizontal comprises of Right and left arrow, A and D, Right and left Joystick
        float speed = Input.GetAxisRaw("Horizontal");

        //tried jump on my own
        //bool jump = Input.GetKey("space");

        //Since, running can be varied, the Speed is a float value
        //Mathf.Abs(speed) fetches the absolute value
        animator.SetFloat("Speed", Mathf.Abs(speed));

        //Vector 3 represents the 3 axes, scale is the size
        // -1 is used for sign change, irrespective of the value of scale
        // if speed is less, ie, the left, A or left joystick is pressed, the scale value will be reversed
        // Hence the animation will flip, and stay there.

        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        /*if (jump)
        {
            animator.setbool("jump", true);
            transform.translate(vector3.up * 3 * time.deltatime, space.world);
        }

        else
        {
            animator.setbool("jump", false);
        }*/


        transform.localScale = scale;
    }
}
