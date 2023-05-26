using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D playerCollider;
    bool isCrouching = false;
    Vector2 originalSize;
    Vector2 crouchSize = new Vector2((float)0.5, 1);

    private void Start()
    {
        Debug.Log("Player Controller Start");
        playerCollider = GetComponent<BoxCollider2D>();
        originalSize = playerCollider.size;

    }
    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        float  jump = Input.GetAxisRaw("Vertical");
       
        animator.SetFloat("Speed", Mathf.Abs(speed));
        animator.SetFloat("Jump", jump);
        animator.SetBool("Crouch", isCrouching);

        Vector3 scale = transform.localScale;

        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        } else if (speed >0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        if (jump < 0)
        {
            scale.y = Mathf.Abs(scale.y);
        }
        transform.localScale = scale;
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            isCrouching = true;
            playerCollider.size = crouchSize;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
        {
            isCrouching = false;
            playerCollider.size = originalSize;
        }

    }

}
