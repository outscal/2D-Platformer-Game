using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    public float moveSpeed;
    public float jumpSpeed;

    public float crouchedColliderOffsetX, crouchedColliderOffsetY;
    public float crouchedColliderSizeX, crouchedColliderSizeY;


    float initialColliderOffsetX, initialColliderOffsetY;
    float initialColliderSizeX, initialColliderSizeY;

    BoxCollider2D boxCollider;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        initialColliderOffsetX = boxCollider.offset.x;
        initialColliderOffsetY = boxCollider.offset.y;
        initialColliderSizeX = boxCollider.size.x;
        initialColliderSizeY = boxCollider.size.y;
    }

    void Update()
    {
        Move();
        Crouch();
        Jump();
    }

    private void Move()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(inputHorizontal));
        Vector3 scale = transform.localScale;
        if (inputHorizontal > 0)
        {
            animator.SetBool("isRunning", true);
            transform.localScale = new Vector3(Mathf.Abs(scale.x), scale.y, scale.z);
            transform.Translate(Time.deltaTime * moveSpeed, 0, 0);
        }
        else if (inputHorizontal < 0)
        {
            animator.SetBool("isRunning", true);
            transform.localScale = new Vector3(-1 * Mathf.Abs(scale.x), scale.y, scale.z);
            transform.Translate(-Time.deltaTime * moveSpeed, 0, 0);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    void Crouch() {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            animator.SetBool("isCrouch", true);
            UpdateColliderSize(boxCollider, crouchedColliderOffsetX, crouchedColliderOffsetY, crouchedColliderSizeX, crouchedColliderSizeY);
        }
        else if (Input.GetKeyUp(KeyCode.RightControl))
        {
            animator.SetBool("isCrouch", false);
            UpdateColliderSize(boxCollider, initialColliderOffsetX, initialColliderOffsetY, initialColliderSizeX, initialColliderSizeY);
        }
    }

    void Jump() {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up*Time.deltaTime * jumpSpeed, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
    }

    private void UpdateColliderSize(BoxCollider2D boxCollider, float offsetX, float offsetY, float sizeX, float sizeY)
    {
        boxCollider.offset = new Vector2(offsetX, offsetY);
        boxCollider.size = new Vector2(sizeX, sizeY);
    }
}
