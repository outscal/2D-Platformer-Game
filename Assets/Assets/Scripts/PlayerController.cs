using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    private float _speedX;
    private float _speedY;

    // Update is called once per frame
    void Update()
    {
        _speedX = Input.GetAxis("Horizontal");
        Vector3 scale = transform.localScale;

        animator.SetFloat("SpeedX", Mathf.Abs(_speedX));

        if (Input.GetKey(KeyCode.LeftShift))
            animator.SetBool("IsRunning", true);
        else animator.SetBool("IsRunning", false);

        if (Input.GetKey(KeyCode.Space))
            animator.SetBool("IsJumping", true);
        else animator.SetBool("IsJumping", false);

        /*if (Input.GetKey(KeyCode.LeftControl))
            animator.SetBool("IsCrouching", true);
        else animator.SetBool("IsCrouching", false);*/

        if (_speedX < 0 && scale.x == 1)
            scale.x *= -1;

        else if (_speedX > 0 && scale.x == -1)
            scale.x *= -1;

        transform.localScale = scale;
    }
}
