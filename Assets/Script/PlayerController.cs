using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D boxCollider2D;


    // Update is called once per frame
    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        // animator.SetFloat("Speed",speed);

        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;



        float jump = Input.GetAxisRaw("Vertical");
        // animator.SetFloat("Jump", Mathf.Abs(jump));
        if (jump > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }



        bool crouch = Input.GetKey("left ctrl");
        if (crouch == true)
        {
            animator.SetBool("Crouch", crouch);
           boxCollider2D.offset = new Vector2(-0.004810318f, 0.6084107f);
           boxCollider2D.size = new Vector2(0.4740263f, 1.351288f);


        }
        else
        {
            animator.SetBool("Crouch", crouch);
           boxCollider2D.offset = new Vector2(-0.004810318f, 0.9641527f);
        //    boxCollider2D.offset = new Vector2(-0.004810318f, 0.9641527f);
           boxCollider2D.size = new Vector2(0.4740263f, 2.012844f);
        }


        // Vector2 S =( gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size)/2;
        // gameObject.GetComponent<BoxCollider2D>().size = S;
        // gameObject.GetComponent<BoxCollider2D>().offset  = new Vector2((S.x),1/2);

        // bool jump = Input.GetKey("w");s
        // bool jump = Input.GetKeyUp("w");
        // bool jump = Input.GetKey("up");

        // animator.SetBool("Jump", jump);



    }
}
