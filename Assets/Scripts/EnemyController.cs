using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Vector3 rayOffset = new Vector3(0.0f, 0.5f, 0.0f);
    public float speed;
    public int movingRight = 1;
    //public GameObject groundDetector;
    public float rayDistance;
    public Animator enemyAnimator;
    public LayerMask layers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        patrolEnemy();
    }

    private void patrolEnemy()
    {
        enemyAnimator.SetBool("IsPatrol", true);
        transform.Translate(movingRight * Vector2.right * speed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayOffset, Vector2.right*movingRight, rayDistance, layers);
        //Debug.DrawLine(transform.position + rayOffset, rayOffset + transform.position + Vector3.right*movingRight * rayDistance, Color.blue);

        if(hit)
        {
            Debug.Log(hit.collider.name);
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            movingRight = movingRight * -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.GetComponent<PlayerController>() != null)
        {
            collision.transform.GetComponent<PlayerController>().DecreaseHealth();
        }
    }
}
