using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    BoxCollider2D bc2d;
    Animator animator;
    SpriteRenderer sr;
    private void Awake() {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        bc2d = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        // Change HorizontalDirection according to input.
        float direction = Input.GetAxisRaw("Horizontal");
        // Set Speed veriable defined in Animator Parameters.
        animator.SetFloat("speed", Mathf.Abs(direction));
        if (direction != 0) {
            sr.flipX = (direction > 0) ? false : true;
        }

        // Jump Animation on Space
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!animator.GetBool("Jump"))
                animator.SetBool("Jump", true);
        } else {
            animator.SetBool("Jump", false);
        }
        

        // Crouch on C
        if (Input.GetKeyDown(KeyCode.C)) {
            // Constant Values Obtained Manually
            float CrouchOffsetX = 0.002846733f;
            float CrouchOffsetY = 0.5938945f;
            float CrouchSizeX = 0.4671042f;
            float CrouchSizeY = 1.247203f;
            if (!animator.GetBool("Crouch"))
                animator.SetBool("Crouch", true);
            bc2d.size = new Vector2(CrouchSizeX, CrouchSizeY);
            bc2d.offset = new Vector2(CrouchOffsetX, CrouchOffsetY);
        } else {
            float OriginalOffsetX = 0.002846733f;
            float OriginalOffsetY = 0.9867451f;
            float OriginalSizeX = 0.4671042f;
            float OriginalSizeY = 2.032904f;

            animator.SetBool("Crouch", false);
            bc2d.size = new Vector2(OriginalSizeX, OriginalSizeY);
            bc2d.offset = new Vector2(OriginalOffsetX, OriginalOffsetY);
        }
    }
}
