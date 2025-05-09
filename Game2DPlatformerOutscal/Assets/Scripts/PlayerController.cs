using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private BoxCollider2D boxCollider;
    private Vector2 boxColOriginalSize;
    private Vector2 boxColOriginalOffSet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxColOriginalSize = boxCollider.size;
        boxColOriginalOffSet = boxCollider.offset;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxis("Horizontal");
        playerAnimator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {

            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;

        float VerticalInput = Input.GetAxis("Vertical");
        playJumpAnimation(VerticalInput);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            crouch(true);
        }
        else
        {
            crouch(false);
        }
    }
    public void crouch(bool crouch)
    {
        if (crouch == true)
        {
            float offsetX = -0.566f;
            float offsetY = 0.61224f;

            float sizeX = 0.84055f;
            float sizeY = 1.34307f;

            boxCollider.offset = new Vector2(offsetX, offsetY);
            boxCollider.size = new Vector2(sizeX, sizeY);

        }
        else
        {
            boxCollider.offset = boxColOriginalOffSet;
            boxCollider.size = boxColOriginalSize;
        }

        playerAnimator.SetBool("Crouch", crouch);

    }
    public void playJumpAnimation(float vertical)
    {
        if (vertical > 0)
        {
            playerAnimator.SetTrigger("Jump");
        }
    }


}
