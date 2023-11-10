using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnim;
    private float speed;
    Vector2 scale;
    private float jumpSpeed;

    private void Start() {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = Input.GetAxisRaw("Horizontal");

        playerAnim.SetFloat("Speed", speed);
        Vector2 scale = transform.localScale;
        if(speed < 0)
        {
            playerAnim.SetFloat("Speed", Mathf.Abs(speed));
            scale.x = -1f * scale.x;
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            playerAnim.SetBool("canCrouch", true);
        }

        jumpSpeed = Input.GetAxisRaw("Vertical");

        if(jumpSpeed>0)
        {
            playerAnim.SetBool("canJump", true);
        }

    }
}
