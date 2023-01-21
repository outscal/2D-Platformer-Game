using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private void Update() {
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
