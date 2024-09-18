using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject point_A;
    [SerializeField] private GameObject point_B;
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PointB")
        {
            speed = -1f;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (collision.gameObject.name == "PointA")
        {
            speed = 1f;
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }

 
    }
}
