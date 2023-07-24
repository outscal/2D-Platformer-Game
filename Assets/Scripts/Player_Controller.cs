using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D collider1;
    public float speed;
    
    // Update is called once per frame
    void Update()
    {
        //horizontalInput(speed) of the player by player input
        float horizontal = Input.GetAxisRaw("Horizontal");
        MovieCharacter(horizontal);
        PlayMovementAnimation(horizontal);

    }
    private void MovieCharacter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }
    //Player Animation Movement function
    private void PlayMovementAnimation(float horizontal)
    {
        //setting the speed parameter to animator
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        //Accessing the scale of the player
        Vector3 scale = transform.localScale;

        //if speed < 0 flip the image in x-axis 
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0) //If speed > 0 then keep the x-axis value positive
        {
            scale.x = Mathf.Abs(scale.x);
        }
        //Set the scale value
        transform.localScale = scale;

        //Crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //Set crouch animation
            Crouch(true, 1.4f, 0.6f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            //Set crouch animation
            Crouch(false, 2.1f, 1);
        }


        //Jump
        float verticalSpeed = Input.GetAxisRaw("Vertical");
        animator.SetFloat("VerticalSpeed", verticalSpeed);
    }

    //Crouch function
    public void Crouch(bool crouch, float sizeY, float offsetY)
    {
        animator.SetBool("Crouch", crouch);
        collider1.size = new Vector2(collider1.size.x, sizeY);
        collider1.offset = new Vector2(collider1.offset.x, offsetY);
    }
}
