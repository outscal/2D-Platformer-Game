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
        originalColliderOffset = collider.offset;
        originalColliderSize = collider.size;
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        bool keyDownCtrl = Input.GetKey(KeyCode.LeftControl);
        bool keyUpCtrl = Input.GetKeyUp(KeyCode.LeftControl);

        PlayCrouchAnimation(keyDownCtrl, keyUpCtrl);

        if (vertical > 0)
            animator.SetBool("isJumpPressed", true);

        if (vertical <= 0)
        {
            animator.SetBool("isJumpPressed", false);
        }

        PlayMovementAnimation(horizontal);
    }

    private void PlayCrouchAnimation(bool keyDownCtrl, bool keyUpCtrl)
    {
        if (keyDownCtrl && isCrouched)
        {
            animator.SetBool("isCrouchStillPressed", true);
            collider.offset = new Vector2(0f, 0.53f);
            collider.size = new Vector2(0.6f, 1.05f);
        }

        if (keyDownCtrl && !isCrouched)
        {
            isCrouched = true;
            animator.SetBool("isCrouchPressed", true);
            collider.offset = new Vector2(0f, 0.53f);
            collider.size = new Vector2(0.6f, 1.05f);
        }

        if (keyUpCtrl && isCrouched)
        {
            isCrouched = false;
            animator.SetBool("isCrouchStillPressed", false);
            collider.offset = originalColliderOffset;
            collider.size = originalColliderSize;
        }

        if (keyUpCtrl && !isCrouched)
        {
            animator.SetBool("isCrouchPressed", false);
            collider.offset = originalColliderOffset;
            collider.size = originalColliderSize;
        }
    }

    private void PlayMovementAnimation(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
}
