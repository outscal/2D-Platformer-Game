using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D boxCollider2D;
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxisRaw("Vertical");

        Vector3 scale = transform.localScale;
        if (speed < 0)
            scale.x = -1 * Mathf.Abs(scale.x);
        else if (speed > 0)
            scale.x = Mathf.Abs(scale.x);
        animator.SetFloat("speed", Mathf.Abs(speed));
        transform.localScale = scale;

        animator.SetBool("jump", (jump > 0));
        animator.SetBool("crouch", Input.GetKey(KeyCode.LeftControl));

        Vector2 offset = boxCollider2D.offset;
        Vector2 size = boxCollider2D.size;
        if (Input.GetKey(KeyCode.LeftControl))
        {
            offset.x = -0.1136989f;
            offset.y = 0.5907992f;
            size.x = 0.8533424f;
            size.y = 1.240493f;
        }
        else
        {
            offset.x = 0.02338372f;
            offset.y = 0.9791999f;
            size.x = 0.5791771f;
            size.y = 2.017294f;
        }
        boxCollider2D.offset = offset;
        boxCollider2D.size = size;
    }
}
