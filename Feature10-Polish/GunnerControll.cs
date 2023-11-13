using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class GunnerControll : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    public float speed;
    private Rigidbody2D rb;
    private Animator ani;
    private Transform currentPoint;

    private void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentPoint = PointB.transform;
        ani.SetBool("isRunning", true);
    }

    private void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == PointB.transform)
        {
            rb.velocity = new Vector2 (speed , 0);
        }
        else
        {
            rb.velocity = new Vector2 (-speed , 0);
        }
        
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointB.transform)
        {
            Flip();
            currentPoint = PointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        {
            Flip();
            currentPoint = PointB.transform;
        }
    }

    private void Flip()
    {
        Vector3 loaclScale = transform.localScale;
        loaclScale.x *= -1;
        transform.localScale = loaclScale;  

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<playerMovement>() != null)
        {
            playerMovement PlayerMovement = collision.gameObject.GetComponent<playerMovement>();
            PlayerMovement.KillPlayer();
        }
    }
}
