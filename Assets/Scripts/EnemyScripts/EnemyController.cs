using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform patrolPointBegin;
    public Transform patrolPointEnd;
    public float movementSpeed;
    public bool bIsGoingLeft = true;
    public Animator anim;
    private bool isTouchingPlayer;
    private bool isDead;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
       
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = patrolPointBegin.position;
        isDead = false;
        spriteRenderer.flipX = bIsGoingLeft;

    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        Vector3 directionTranslation = (bIsGoingLeft) ? -transform.right : transform.right;
        directionTranslation *= Time.deltaTime * movementSpeed;
        transform.Translate(directionTranslation);
        if(Vector2.Distance(transform.position, patrolPointEnd.position) < 1)
        {
            bIsGoingLeft = true;
            spriteRenderer.flipX = bIsGoingLeft;
        }
        if (Vector2.Distance(transform.position, patrolPointBegin.position) < 1)
        {
            bIsGoingLeft = false;
            spriteRenderer.flipX = bIsGoingLeft;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Player Entered");
            isTouchingPlayer = true;
            anim.SetBool("IsTouchingPlayer", isTouchingPlayer);
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Player Exit");
            isTouchingPlayer = false;
            anim.SetBool("IsTouchingPlayer", isTouchingPlayer);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            collision.gameObject.GetComponent<PlayerController>().DecreaseHealth();
        }
    }

}
