using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D player;

    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log("Player controller awake");
    }
    private void Start()
    {
        player.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame   
    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
       

        Vector3 scale = transform.localScale;

        if(speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isSit", true);
            player.size = new Vector2(0.47f,1.22f);
            player.offset = new Vector2(-0.04f, 0.59f);
            
        }
        float jump = Input.GetAxisRaw("Vertical");
        animator.SetBool("isJump", true);
        if (jump > 0) ;
        {
            
            animator.SetBool("isJump", true);
            animator.SetBool("isSit", false);
            player.offset = new Vector2(-0.04f, 0.98f);
            player.size = new Vector2(0.47f, 2.011f);
        }
    }
}
