using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public bool isCrouched;
    public new BoxCollider2D collider;
    public Vector2 originalColliderOffset;
    public Vector2 originalColliderSize;

    private void Awake()
    {
        Debug.Log("Player Controller: awake");
        // Debug.Log("Collider: " + collider.size.y);
        originalColliderOffset = collider.offset;
        originalColliderSize = collider.size;
    }

    private void Update()
    {
        float speedX = Input.GetAxisRaw("Horizontal");
        float speedY = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(speedX));

        bool keyDownCtrl = Input.GetKey(KeyCode.LeftControl);
        bool keyUpCtrl = Input.GetKeyUp(KeyCode.LeftControl);

        if(keyDownCtrl && isCrouched)
        {
            animator.SetBool("isCrouchStillPressed", true);
            collider.offset = new Vector2(0f, 0.5331f);
            collider.size = new Vector2(0.596997f, 1.1809f);
        }

        if(keyDownCtrl && !isCrouched)
        {
            isCrouched = true;
            animator.SetBool("isCrouchPressed", true);
            collider.offset = new Vector2(0f, 0.5331553f);
            collider.size = new Vector2(0.596997f, 1.05f);
        }

        if (keyUpCtrl && isCrouched)
        {
            isCrouched = false;
            animator.SetBool("isCrouchStillPressed", false);
            collider.offset = originalColliderOffset;
            collider.size = originalColliderSize;
        }

        if(keyUpCtrl && !isCrouched)
        {
            animator.SetBool("isCrouchPressed", false);
            collider.offset = originalColliderOffset;
            collider.size = originalColliderSize;
        }

        if (speedY > 0)
            animator.SetBool("isJumpPressed", true);
        
        if(speedY <= 0)
        {
            animator.SetBool("isJumpPressed", false);
        }

        Vector3 scale = transform.localScale;

        if (speedX < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        } else if(speedX > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
}
