using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed; 
    [SerializeField] float jump;
    BoxCollider2D bc2d;
    Animator animator;
    SpriteRenderer sr;
    Rigidbody2D rb2d;
    public bool isPlayerGrounded = false;

    private void Awake() {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        bc2d = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void AnimateJump(float vertical) {
        if (vertical > 0 && isPlayerGrounded) {
            animator.SetBool("Jump", true);
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        } else {
            animator.SetBool("Jump", false);
        }
    }

    private void AnimateCrouch() {
        if (Input.GetKey(KeyCode.C)) {
            // Constant Values Obtained Manually
            float CrouchOffsetX = 0.002846733f;
            float CrouchOffsetY = 0.5938945f;
            float CrouchSizeX = 0.4671042f;
            float CrouchSizeY = 1.247203f;

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

    private void AnimateHorizontalMovement(float horizontal) {
        // Set Speed variable defined in Animator Parameters.
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        if (horizontal != 0) {
            sr.flipX = (horizontal > 0) ? false : true;
        }

        // Player Movement
        Vector3 currPos = transform.position;
        currPos.x += horizontal * speed * Time.deltaTime;
        transform.position = currPos;
    }

    private void AnimateVerticalMovement(float vertical) {
        // Jump Animation
        AnimateJump(vertical);
        // Crouch on C
        AnimateCrouch();
    }

    private void Update() {
        // Change HorizontalDirection according to input.
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        AnimateHorizontalMovement(horizontal);
        AnimateVerticalMovement(vertical);   
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.transform.tag == "Platform")
            isPlayerGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.transform.tag == "Platform")
            isPlayerGrounded = false;
    }
}
