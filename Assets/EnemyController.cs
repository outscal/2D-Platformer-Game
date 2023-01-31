using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyController : MonoBehaviour
{
    public Animator animator;
    RaycastHit2D hit;
    public float speed;
    int right = 1;
    private Vector3 Position;
    BoxCollider2D BoxCollider2D;
    Rigidbody2D rb2d;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       /*if( collision.gameObject.GetComponent<PlayerController>() != null)
        {
            SceneManager.LoadScene(0);
        }
        right *= -1;*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Patrol"))
        {
            right = -1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.DrawRay(Position, transform.position);
        rb2d = GetComponent<Rigidbody2D>();
       hit = Physics2D.Raycast(transform.position, transform.forward, speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Position = transform.position;
        /* if (hit.collider == null)
         {
             if (isRight())
             {
                 Position.x = Position.x + speed * Time.deltaTime;
                 right = 1;
             }

             else
             {
                 Position.x = -(Position.x + speed * Time.deltaTime);
                 right = -1;
             }

         }*/
        //transform.position = new Vector3(Position.x,0,0);
        transform.localScale = new Vector3(right, 1, 1f);
        rb2d.velocity = new Vector2((int)(speed*right*1.5), 0f);
    }

    private bool isRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
}
