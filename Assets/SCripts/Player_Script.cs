using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("SPEED", Mathf.Abs(speed));

        float Jump = Input.GetAxisRaw("Vertical");
        animator.SetFloat("JUMP", Jump);

        bool Crounch = Input.GetKey(KeyCode.LeftControl);
        animator.SetBool("CROUNCH", Crounch);

        Vector3 scale = transform.localScale;
        if (speed < 0)
        scale.x = -1f * Mathf.Abs(scale.x);  
        else if (speed > 0)
        scale.x = Mathf.Abs(scale.x);

        transform.localScale = scale;
    }

}
