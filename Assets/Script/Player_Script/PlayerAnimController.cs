using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private BoxCollider2D boxCol;

    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;

    private void Start()
    {
        boxColInitSize = boxCol.size;
        boxColInitOffset = boxCol.offset;
    }

    public void PlayMoveAnim(float horizontal, Transform playerTransform)
    {
        playerAnimator.SetFloat("horizontal", Mathf.Abs(horizontal));

        Vector2 scale = playerTransform.localScale;

        if (horizontal < 0)
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        playerTransform.localScale = scale;
    }

    public void PlayJumpAnim(bool isGrounded)
    {
        if (!isGrounded)
        {
            playerAnimator.SetBool("Jump", true);
        }
        else
        {
            playerAnimator.SetBool("Jump", false);
        }
    }

    public void PlayCrouchAnim(bool isCrouch)
    {
        if (isCrouch)
        {
            float offX = -0.0978f;
            float offY = 0.5947f;

            float sizeX = 0.6988f;
            float sizeY = 1.3398f;

            boxCol.size = new Vector2(sizeX, sizeY);
            boxCol.offset = new Vector2(offX, offY);
        }
        else
        {
            boxCol.size = boxColInitSize;
            boxCol.offset = boxColInitOffset;
        }

        playerAnimator.SetBool("Crouch", isCrouch);
    }
}
