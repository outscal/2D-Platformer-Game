using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private BoxCollider2D playerCol;
    public float speed;
    
//    private void Awake()
//    {
    //    Debug.Log("Player Controller awake");
//    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Collision : " + collision.gameObject.name);
    //}

    void Start()
    {
        Debug.Log("Start Function ");
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        MoveCharacter(horizontal);
        PlayMovementAnimation(horizontal);
    }

    private void MoveCharacter(float horizontal)
    {
        Vector2 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
        
    }
    private void PlayMovementAnimation(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector2 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;


        float jump = Input.GetAxisRaw("Jump");
        if (jump > 0)
        {
        animator.SetBool("JUMP", true);
        }
        else
        {
        animator.SetBool("JUMP", false);
        }


        bool isCrouching = Input.GetKey(KeyCode.LeftControl);
        animator.SetBool("isCrouch", isCrouching);
        playerCol = animator.GetComponent<BoxCollider2D>();
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isCrouching = true;
            playerCol.size = new Vector2(playerCol.size.x, 1.33f);
            playerCol.offset = new Vector2(playerCol.offset.x, 0.59f);
        }
    }

}
