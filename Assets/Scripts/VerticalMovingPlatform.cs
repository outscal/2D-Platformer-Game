using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingPlatform : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject endPoint;
    public float speed;
    public GameObject player;

    private Rigidbody2D rb;
    private bool movingUp = true;
    private bool isPlayerOnPlatform = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isPlayerOnPlatform == true)
        {
            if (movingUp)
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
            else
            {
                transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            }
        }
               
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == startPoint)
        {
            movingUp = true;
        }
        else if (collision.gameObject == endPoint)
        {
            movingUp = false;
        }
    }

    void FixedUpdate()
    {
        if (isPlayerOnPlatform)
        {
            Vector3 platformVelocity = GetComponent<Rigidbody2D>().velocity;
            player.GetComponent<Rigidbody2D>().velocity = platformVelocity;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 0f;
            isPlayerOnPlatform = true;
            player.transform.SetParent(transform);
        }
    }
   
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 1f;
            isPlayerOnPlatform = false;
            player.transform.SetParent(null);
        }        
    }
}
