using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public Animator animator;

    public float speed;
    private void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        bool Crouch = Input.GetKey(KeyCode.LeftControl);

        Player_Horizontal(Horizontal);
        Player_Crouch(Crouch);
    }

    private void Player_Horizontal(float horizontal)
    {
        animator.SetFloat("SPEED", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
            scale.x = -1f * Mathf.Abs(scale.x);
        else if (horizontal > 0)
            scale.x = Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    private void Player_Crouch(bool Crnch)
    {
        if (Crnch == true)
          animator.SetBool("CROUNCH", true);
        else
          animator.SetBool("CROUNCH", false);
    }
}
