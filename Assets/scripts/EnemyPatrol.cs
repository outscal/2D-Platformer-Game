using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform[] PatrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    public int damage;
    public PlayerHealth playerHealth;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (patrolDestination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, PatrolPoints[0].position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, PatrolPoints[0].position) < .2f)
            {
                patrolDestination = 1;
            }
        }
        if (patrolDestination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, PatrolPoints[1].position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, PatrolPoints[1].position) < .2f)
            {
                patrolDestination = 0;
            }
        }
       
    }
}
