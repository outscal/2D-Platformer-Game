using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public float crouchedColliderOffsetX, crouchedColliderOffsetY;
    public float crouchedColliderSizeX, crouchedColliderSizeY;


    float initialColliderOffsetX, initialColliderOffsetY;
    float initialColliderSizeX, initialColliderSizeY;

    BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        initialColliderOffsetX = boxCollider.offset.x;
        initialColliderOffsetY = boxCollider.offset.y;
        initialColliderSizeX = boxCollider.size.x;
        initialColliderSizeY = boxCollider.size.y;
    }

    void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        //Debug.Log(inputHorizontal);
        animator.SetFloat("Speed", Mathf.Abs(inputHorizontal));
        Vector3 scale = transform.localScale;
        if (inputHorizontal > 0)
        {
            animator.SetBool("isRunning", true);
            transform.localScale = new Vector3(Mathf.Abs(scale.x), scale.y, scale.z);
        }
        else if (inputHorizontal < 0)
        {
            animator.SetBool("isRunning", true);
            transform.localScale = new Vector3(-1 * Mathf.Abs(scale.x), scale.y, scale.z);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

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

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
            animator.SetTrigger("Jump");
        }
    }

    private void UpdateColliderSize(BoxCollider2D boxCollider, float offsetX, float offsetY, float sizeX, float sizeY)
    {
        boxCollider.offset = new Vector2(offsetX, offsetY);
        boxCollider.size = new Vector2(sizeX, sizeY);
    }
}
