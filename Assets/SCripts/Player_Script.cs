using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public Animator animator;

    public float speed;
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        bool Jump = Input.GetKey(KeyCode.Space);
        bool Crouch = Input.GetKey(KeyCode.LeftControl);
       
        Player_Horizontal(horizontal,Jump);
        Player_Crouch(Crouch);
        Player_move(horizontal);
    }

    private void Player_Horizontal(float horizontal,bool vertical)
    {
        animator.SetFloat("SPEED", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
            scale.x = -1f * Mathf.Abs(scale.x);
        else if (horizontal > 0)
            scale.x = Mathf.Abs(scale.x);

        transform.localScale = scale;

        if (vertical == true)
            animator.SetBool("JUMP", vertical);
        else
            animator.SetBool("JUMP", false);
    }

    private void Player_move(float horizontal)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;
    }
    private void Player_Crouch(bool Crnch)
    {
        if (Crnch == true)
          animator.SetBool("CROUNCH", true);
        else
          animator.SetBool("CROUNCH", false);
    }
}
