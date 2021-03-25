using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D playerCollider;
    public float initialYoffset, initialYsize, crouchYoffset = 0.07785285f, crouchYsize= 1.278029f;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        initialYoffset=playerCollider.offset.y; 
        initialYsize = playerCollider.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        

        float playerSpeed = Input.GetAxisRaw("Horizontal");
        //Debug.Log("Player Speed is:"+playerSpeed);
        animator.SetFloat("Speed", Mathf.Abs(playerSpeed));
        Vector3 scale = transform.localScale;
        if (playerSpeed<0)
        {
            scale.x = -1f* Mathf.Abs(scale.x);

        }
        else if (playerSpeed>0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", true);
            playerCollider.offset =new Vector2(playerCollider.offset.x ,crouchYoffset);
            playerCollider.size = new Vector2(playerCollider.size.x, crouchYsize);
        }
        else
        {
            animator.SetBool("isCrouch", false);
            playerCollider.offset = new Vector2(playerCollider.offset.x, initialYoffset);
            playerCollider.size = new Vector2(playerCollider.size.x, initialYsize);
        }
        float canJump = Input.GetAxisRaw("Vertical");
        if(canJump>0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}
