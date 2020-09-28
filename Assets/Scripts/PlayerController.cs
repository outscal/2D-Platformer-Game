using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private BoxCollider2D player;
    private Rigidbody2D rb2d;
    private void Awake()
    {
        player = gameObject.GetComponent<BoxCollider2D>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();

    }
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        //Running and turning
        LeftRight();
        //Crouching
        Crouch();
        //Jumping
        Jump();
    }

    void LeftRight() {
        float speed = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            if (speed < -0.5 && !Input.GetKey(KeyCode.LeftControl))
            {
                transform.position += Vector3.right * 3 * speed * Time.deltaTime;
            }
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            if (speed > 0.5 && !Input.GetKey(KeyCode.LeftControl))
            {
                transform.position += Vector3.right * 3 * speed * Time.deltaTime;
            }
        }
        transform.localScale = scale;
    }
    void Crouch() {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            animator.SetBool("IsCrouch", true);
            player.size = new Vector2(player.size.x, (player.size.y) * 0.6f);
            player.offset = new Vector2(player.offset.x, (player.offset.y) * 0.6f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
        {
            animator.SetBool("IsCrouch", false);
            player.size = new Vector2(player.size.x, (player.size.y) / 0.6f);
            player.offset = new Vector2(player.offset.x, (player.offset.y) / 0.6f);
        }
    }
    void Jump() {
        /*float jump = Input.GetAxis("Jump");
       if (jump > 0)
       {
           animator.SetBool("Jump", true);
           rb2d.AddForce(new Vector2(0, jump*40), ForceMode2D.Force);
       }
       else {
           animator.SetBool("Jump", false);
       }*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(new Vector2(0, 28), ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Jump", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Jump", false);
        }
    }
}   
