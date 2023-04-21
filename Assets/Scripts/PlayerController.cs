using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider2D;

    [SerializeField] Vector2 boxColliderOffset;
    [SerializeField] Vector2 boxColliderSize;

    private Vector2 initialSize, initialOffset;

    private void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
        initialOffset = gameObject.GetComponent<BoxCollider2D>().offset;
        initialSize = gameObject.GetComponent<BoxCollider2D>().size;
    }

    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        bool isCrouch = Input.GetKey(KeyCode.LeftControl);
        bool isJump = Input.GetKeyDown(KeyCode.Space);

        // Player Crouch Animation trigger
        if (isCrouch)
        {
            // If Left Control is Pressed, then player will crouch
            // Also need to resize the box collider
            animator.SetBool("Crouch", isCrouch);
            gameObject.GetComponent<BoxCollider2D>().offset = boxColliderOffset;
            gameObject.GetComponent<BoxCollider2D>().size = boxColliderSize;
        } else
        {
            animator.SetBool("Crouch", isCrouch);
            gameObject.GetComponent<BoxCollider2D>().offset = initialOffset;
            gameObject.GetComponent<BoxCollider2D>().size = initialSize;
        }

        animator.SetFloat("Speed", Mathf.Abs(speed));

        if (speed < 0)
        {
            spriteRenderer.flipX = true;
        } else if (speed > 0) 
        { 
            spriteRenderer.flipX= false;
        }
        // Player Jump
        if(isJump)
        {
            animator.SetBool("Jump", isJump);
            Debug.Log("Space was pressed\n");
        } else
        {
            animator.SetBool("Jump", false);
        }
    }
}
