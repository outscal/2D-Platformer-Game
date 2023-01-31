using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator animator;
    SpriteRenderer spriteRenderer;
    public Collider2D collider_stand;
    public Collider2D collider_crouch;
    Rigidbody2D rigidBody;

    public float vMax = 8;
    public float jumpThrust = 200;

    private bool inAir = false;
    private bool isCrouching = false;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {

        if (!inAir) {
            if (!isCrouching) {

                // jump code
                if (Input.GetButtonDown("Jump")) {
                    animator.SetTrigger("jump");

                    rigidBody.AddForce(new Vector2(0, jumpThrust));
                }
            }

            isCrouching = Input.GetButton("Crouch");

            // crouch code
            animator.SetBool("crouch", isCrouching);

            // managing collisions when crouch
            collider_stand.enabled = !isCrouching;
            collider_crouch.enabled = isCrouching;
        }

        // walk and run code
        float vX = Input.GetAxisRaw("Horizontal");

        // you can walk by slightly pushing the L-Stick
        animator.SetFloat("speed", Mathf.Abs(vX * 10));

        // flipping the sprite
        if (vX > 0) {
            spriteRenderer.flipX = false;
        } else if (vX < 0) {
            spriteRenderer.flipX = true;
        }

        // actually moving the player around
        Vector3 p = transform.position;
        p.x += vX * vMax * Time.deltaTime;
        transform.position = p;

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "ground") {
            inAir = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.tag == "ground") {
            inAir = true;
        }
    }

}
