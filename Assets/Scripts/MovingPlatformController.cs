using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject endPoint;
    private Rigidbody2D rb;
    public float speed;
    private bool movingRight = true;
    public GameObject player;
    private bool isPlayerOnPlatform = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (movingRight)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
    void FixedUpdate()
    {
        if (isPlayerOnPlatform)
        {
            Vector2 platformVelocity = GetComponent<Rigidbody2D>().velocity;
            player.GetComponent<Rigidbody2D>().velocity = platformVelocity;
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            isPlayerOnPlatform = true;
            player.transform.SetParent(transform); // Set the platform as the parent of the player
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            isPlayerOnPlatform = false;
            player.transform.SetParent(null); // Remove the platform as the parent of the player
        }
    }
}
