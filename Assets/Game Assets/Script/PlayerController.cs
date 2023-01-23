using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Collider2D collider_stand;
    public Collider2D collider_crouch;

    private void Update() {

        // if crouch
        if (Input.GetButton("Crouch")) {
            animator.SetBool("crouch", true);

            collider_stand.enabled = false;
            collider_stand.enabled = true;

        } else {
            animator.SetBool("crouch", false);
            collider_stand.enabled = true;
            collider_stand.enabled = false;

            // if jump - works for joystick?
            if (Input.GetButton("Jump")) {
                animator.SetBool("jump", true);

            } else {
                animator.SetBool("jump", false);

                float speed = Input.GetAxisRaw("Horizontal");

                // joystick works amazingly now
                animator.SetFloat("speed", Mathf.Abs(speed * 10));

                // flipping the sprite
                if (speed > 0) {
                    spriteRenderer.flipX = false;
                } else if (speed < 0) {
                    spriteRenderer.flipX = true;
                }
            }
        }


    }

}
