using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D collider1;
    
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

        //Crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //Set crouch animation
            animator.SetBool("Crouch", true);
            collider1.size = new Vector2(collider1.size.x, 1.4f);
            collider1.offset = new Vector2(collider1.offset.x, 0.6f);
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            //Set crouch animation
            animator.SetBool("Crouch", false);
            collider1.size = new Vector2(collider1.size.x, 2.1f);
            collider1.offset = new Vector2(collider1.offset.x, 1);
        }

        //Jump
        float verticalSpeed = Input.GetAxisRaw("Vertical");
        animator.SetFloat("VerticalSpeed", verticalSpeed);
       
    }
}
