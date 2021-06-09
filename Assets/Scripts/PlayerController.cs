using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
 
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
    }
}
