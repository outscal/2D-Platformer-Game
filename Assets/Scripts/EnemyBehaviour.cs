using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField]
    private Transform[] PatrollingPoint;
    [SerializeField]
    private float Speed;
    private Animator anim;
    private Rigidbody2D rb;
    private Transform Currenpoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Currenpoint = PatrollingPoint[0].transform;
        anim.SetBool("IsRunning", true);
    }

    private void Patrolling(int CP, int TP)
    {
        if(Currenpoint == PatrollingPoint[CP])
        {
            transform.position = Vector2.MoveTowards(transform.position, PatrollingPoint[CP].transform.position, Speed*Time.deltaTime);
            if (Vector2.Distance(transform.position, PatrollingPoint[CP].transform.position)<0.2f)
            {
                flip();
                Currenpoint = PatrollingPoint[TP];
            }
        }
    }

    private void flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PatrollingPoint[0].position, 0.5f);
        Gizmos.DrawWireSphere(PatrollingPoint[1].position, 0.5f);
        Gizmos.DrawLine(PatrollingPoint[0].position, PatrollingPoint[1].position);
    }

    private void Update()
    {
        Patrolling(0,1);
        Patrolling(1, 0);
    }
}
