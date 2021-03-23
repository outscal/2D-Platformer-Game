using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    /*private void OnCollisionEnter20(Collision2D collision)
    {
        Debug.Log("collision" + collision.gameObject.name);
    }
    */

    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        bool crouch = Input.GetKey(KeyCode.LeftControl);

        animator.SetFloat("Speed", Mathf.Abs(speed));
        animator.SetBool("crouch", crouch);

        Vector3 scale = transform.localScale;

        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
}
