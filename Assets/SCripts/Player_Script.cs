using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rbdy;
    public float speed;
    public float Jump;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        bool Crouch = Input.GetKey(KeyCode.LeftControl);
       
        Player_Horizontal(horizontal,vertical);
        Player_Crouch(Crouch);
        Player_move(horizontal,vertical);

        rbdy = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Player_Horizontal(float horizontal,float vertical)
    {
        animator.SetFloat("SPEED", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
            scale.x = -1f * Mathf.Abs(scale.x);
        else if (horizontal > 0)
            scale.x = Mathf.Abs(scale.x);

        transform.localScale = scale;

        if (vertical>0)
            animator.SetBool("JUMP", true);
        else
            animator.SetBool("JUMP", false);
    }

    private void Player_move(float horizontal,float vertical)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;

        if(vertical>0)
        {
            rbdy.AddForce(new Vector2(0f,Jump), ForceMode2D.Force);
        }
    }
    private void Player_Crouch(bool Crnch)
    {
        if (Crnch == true)
          animator.SetBool("CROUNCH", true);
        else
          animator.SetBool("CROUNCH", false);
    }
}
