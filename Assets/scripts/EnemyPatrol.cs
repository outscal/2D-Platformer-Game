using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform[] PatrolPoints;
    public float moveSpeed;
    public int patrolDestination;



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
