using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2d;
    public float speed;
    public float jump;
    private bool is_grounded;

    private void Awake() {
        animator = gameObject.GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update(){
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        PlayerAnimation(horizontal, vertical);
        PlayerMovement(horizontal, vertical);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            is_grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            is_grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Respawn"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void PlayerMovement(float horizontal, float vertical){
        // Horizontal movement of the player
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        // Jump Movement
        if (vertical > 0 && is_grounded) {
            rb2d.AddForce(new Vector2(0.0f, jump), ForceMode2D.Force);
        }
    }

    void PlayerAnimation(float horizontal, float vertical){
        // Run and Idle Animation
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        // Rotating the player
        Vector3 scale = transform.localScale;
        if (horizontal < 0){
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0) {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        // Jump Animation
        if (vertical > 0 && is_grounded) {
            animator.SetBool("jump", true);
        } else if (vertical == 0) {
            animator.SetBool("jump", false);
        }
    }
}
