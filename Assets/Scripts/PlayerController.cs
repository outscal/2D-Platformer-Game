using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D boxcollider;
    Vector2 size;
    Vector2 offset;
    private void Awake()
    {
        size = boxcollider.size;
        offset = boxcollider.offset;
    }


    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        PlayerFlip();
        PlayerCrouch();
        PlayerJump();
    }

    private void PlayerFlip()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
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

    private void PlayerJump()
    {
        float speedY = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Jump", Mathf.Abs(speedY));
    }

    private void PlayerCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
            boxcollider.size = new Vector2(size.x, size.y / 2);
            boxcollider.offset = new Vector2(offset.x, offset.y - offset.y / 2);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            boxcollider.size = size;
            boxcollider.offset = offset;
            animator.SetBool("Crouch", false);
        }
    }
}
