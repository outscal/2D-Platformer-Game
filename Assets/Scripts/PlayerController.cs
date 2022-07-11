using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public bool isCrouched;
    public new BoxCollider2D collider;
    public Vector2 originalColliderOffset;
    public Vector2 originalColliderSize;
    public float speed;

    private void Awake()
    {
        Debug.Log("Player Controller: awake");
        originalColliderOffset = collider.offset;
        originalColliderSize = collider.size;
    }

    private void Update()
    {
        // input mapping
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool keyDownCtrl = Input.GetKey(KeyCode.LeftControl);
        bool keyUpCtrl = Input.GetKeyUp(KeyCode.LeftControl);

        PlayCrouchAnimation(keyDownCtrl, keyUpCtrl);

        MoveCharacter(horizontal);
        PlayMovementAnimation(horizontal, vertical);
    }
    private void PlayCrouchAnimation(bool isKeyDownCrouch, bool isKeyUpCrouch)
    {
        if (isKeyDownCrouch && isCrouched)
        {
            animator.SetBool("isCrouchStillPressed", true);
            collider.offset = new Vector2(0f, 0.53f);
            collider.size = new Vector2(0.6f, 1.05f);
        }

        if (isKeyDownCrouch && !isCrouched)
        {
            isCrouched = true;
            animator.SetBool("isCrouchPressed", true);
            collider.offset = new Vector2(0f, 0.53f);
            collider.size = new Vector2(0.6f, 1.05f);
        }

        if (isKeyUpCrouch && isCrouched)
        {
            isCrouched = false;
            animator.SetBool("isCrouchStillPressed", false);
            collider.offset = originalColliderOffset;
            collider.size = originalColliderSize;
        }

        if (isKeyUpCrouch && !isCrouched)
        {
            animator.SetBool("isCrouchPressed", false);
            collider.offset = originalColliderOffset;
            collider.size = originalColliderSize;
        }
    }

    private void PlayMovementAnimation(float horizontal, float vertical)
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


        if (vertical > 0)
            animator.SetBool("isJumpPressed", true);

        if (vertical <= 0)
        {
            animator.SetBool("isJumpPressed", false);
        }
    }

    private void MoveCharacter(float horizontal)
    {
        //move character horizontally
        Vector2 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //move character vertically

    }
}
