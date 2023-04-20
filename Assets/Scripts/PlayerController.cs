using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        if (speed < 0)
        {
            spriteRenderer.flipX = true;
        } else if (speed > 0) { 
            spriteRenderer.flipX= false;
        }
    }
}
