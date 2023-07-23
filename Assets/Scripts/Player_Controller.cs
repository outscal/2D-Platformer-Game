using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        //speed of the player by player input
        float speed = Input.GetAxisRaw("Horizontal");

        //setting the speed parameter to animator
        animator.SetFloat("Speed", Mathf.Abs(speed));

        //Accessing the scale of the player
        Vector3 scale = transform.localScale;

        //if speed < 0 flip the image in x-axis 
        if(speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(speed > 0) //If speed > 0 then keep the x-axis value positive
        {
            scale.x = Mathf.Abs(scale.x);
        }
        //Set the scale value
        transform.localScale = scale;
    }
}
