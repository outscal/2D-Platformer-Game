using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sr;
    private void Awake() {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        // Change Direction according to input.
        float direction = Input.GetAxisRaw("Horizontal");
        // Set Speed veriable defined in Animator Parameters.
        animator.SetFloat("speed", Mathf.Abs(direction));
        if (direction != 0) {
            sr.flipX = (direction > 0) ? false : true;
        }
    }
}
