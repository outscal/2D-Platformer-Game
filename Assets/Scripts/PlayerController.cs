using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private BoxCollider2D boxCollider2D;
    float offsetX;
    float offsetY;
    float sizeX;
    float sizeY;

    private void Awake ()
    {
        Debug.Log("awake");
    }
    private void Start ()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
   
    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed",Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if(speed <0)
        { 
            

            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
           
            scale.x = Mathf.Abs(scale.x);   
        }
        transform.localScale =scale; 


        float jumpinput = Input.GetAxis("Vertical");
        jumpAnim(jumpinput);

        if(Input.GetKey(KeyCode.LeftControl))
        {
            CrouchAnim(true);
        }
        else{
            CrouchAnim(false);
        }
    }
    private void jumpAnim(float input)
    {
        if(input > 0 )
        {
            animator.SetBool("Jump", true);
        }
        else{
             animator.SetBool("Jump", false);
        }
    }
    private void CrouchAnim(bool Crouch)
    {
         if (Crouch == true)
        {
            offsetX = -0.08742696f;
            offsetY = 0.6050405f;          //Offset Y

            sizeX = 0.6085089f;               //Size X
            sizeY = 1.180404f;               //Size Y
        }

        else
        {
            offsetX = -0.002331734f;
            offsetY = 0.9794595f;           //Offset Y

            sizeX =  0.4383185f;             //Size X
            sizeY = 1.929242f;              //Size Y
        }
        animator.SetBool("Crouch", Crouch);

        boxCollider2D.size = new Vector3(sizeX, sizeY);     //Setting the size of collider
        boxCollider2D.offset = new Vector3(offsetX, offsetY); 
    }
    
}
