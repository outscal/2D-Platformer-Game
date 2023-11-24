using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    public Animator anim;
    private Transform currentPoint;
    public float speed;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = PointB.transform;
        anim.SetBool("IsRunning", true);
    }

    private void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == PointB.transform)
        {
            rb.velocity = new Vector2(speed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0f);
        }

        if(Vector2.Distance(transform.position , currentPoint.position) < 0.5f && currentPoint == PointB.transform)
        {
            flip();
            currentPoint = PointA.transform;
        }
        else if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        {
            flip();
            currentPoint = PointB.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.takeDamage(1);
        }
    }


    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
