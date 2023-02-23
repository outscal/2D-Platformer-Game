using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public Transform platformStartPoint;
    public Transform platformEndPoint;
    public bool moveRight = true;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (transform.position.x <= platformStartPoint.position.x)
        {
            moveRight = true;
            spriteRenderer.flipX = false;
        }
        else if (transform.position.x >= platformEndPoint.position.x)
        {
            moveRight = false;
            spriteRenderer.flipX = true;
        }

        if (moveRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if( playerController != null)
        {
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {


                playerController.KillPlayer();
            }
            else
            {
                StartCoroutine(GetHurt());
            }

        } 
            
            
        
    }
    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(7, 8);
        GetComponent<Animator>().SetLayerWeight(0, 1);
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetLayerWeight(0, 0);
        Physics2D.IgnoreLayerCollision(7,8, false);
    }
   

}