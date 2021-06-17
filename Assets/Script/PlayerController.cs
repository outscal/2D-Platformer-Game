using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;
    public BoxCollider2D boxCollider2D;
    private Rigidbody2D rb2D;



    private void Awake()
    {
        //awake is used to intialize any variable or game state before game starts
        //awake is always called before satrt function
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        float horizantal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");      //use "Jump" or "Vertical" both are same
        bool crouch = Input.GetKey("left ctrl");
        MoveCharacter(horizantal, vertical);
        PlayMovementAniamation(horizantal, vertical, crouch);

    }

    private void MoveCharacter(float horizantal, float vertical)
    {
        //Move horizaontally
        RunChar(horizantal);

        // Move Verically
        JumpChar(vertical);

    }

    void RunChar(float horizantal)
    {
        Vector3 pos = transform.position;
        pos.x += horizantal * speed * Time.deltaTime;
        transform.position = pos;
    }

    void JumpChar(float vertical)
    {
        if (vertical > 0)
        {
            rb2D.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }
    private void PlayMovementAniamation(float horizantal, float vertical, bool crouch)
    {
        RunAnim(horizantal);
        JumpAnim(vertical);
        CrouchAnim(crouch);
    }

    void RunAnim(float horizantal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizantal));
        Vector3 scale = transform.localScale;
        if (horizantal < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (horizantal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

    }

    void JumpAnim(float vertical)
    {
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }


    void CrouchAnim(bool crouch)
    {
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
            boxCollider2D.size = new Vector2(0.4740263f, 2.012844f);
        }
    }

}
