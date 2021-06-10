using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Animator animator;
    private BoxCollider2D boxcollider2d;

    public float crouchOffSetx, crouchOffSety;
    public float crouchSizex, crouchSizey;
    public float offsetx, offsety;
    public float sizex, sizey;


    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        boxcollider2d = gameObject.GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        PlayerAnimation(horizontal, vertical);
    }

    private void PlayerAnimation(float horizontal, float vertical)
    {
        //horizontal animation
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

        //vertical animation
        if (vertical > 0)
        {
            animator.SetBool("IsJump", true);
        }
        else
        {
            animator.SetBool("IsJump", false);
        }

        //crouch animation
        if(Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("IsCrouch", true);
            boxcollider2d.offset = new Vector2(crouchOffSetx, crouchOffSety);
            boxcollider2d.size = new Vector2(crouchSizex, crouchSizey);
        }
        else
        {
            animator.SetBool("IsCrouch", false);
            boxcollider2d.offset = new Vector2(offsetx, offsety);
            boxcollider2d.size = new Vector2(sizex, sizey);
        }
    }
}
