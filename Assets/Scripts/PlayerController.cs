using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    float speed;
    public float jump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
    }

    void playerMovement()
    {
        speed = Input.GetAxisRaw("Horizontal");
        jump = Input.GetAxisRaw("Vertical");
        animator.SetFloat("speed",Mathf.Abs(speed));

        Vector2 scale = transform.localScale;
        if (speed < 0f)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", false);
        }

        if(jump>0)
        {
            animator.SetBool("jump", true);
        }
        else if(jump<=0)
        {
            animator.SetBool("jump", false);

        }


        transform.localScale = scale;
    }
}
