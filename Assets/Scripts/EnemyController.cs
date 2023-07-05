using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public GameObject startPoint;
    public GameObject endPoint;
    private Rigidbody2D rb;
    private Animator anim;
    public float speed;
    private bool movingRight = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("IsWalk", true);
      
    }
    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (movingRight && transform.localScale.x < 0 || !movingRight && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == startPoint)
        {
            movingRight = true;
        }
        else if (collision.gameObject == endPoint)
        {
            movingRight = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() != null)
        {            
            playerHealth.TakeDamage(1);
        }
    }
    
}

