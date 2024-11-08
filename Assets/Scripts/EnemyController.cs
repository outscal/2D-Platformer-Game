using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public Transform A;
    [SerializeField] public Transform B;

   
    private Animator anim;
    private Vector3 currentPoint;
    public float speed;

    private SpriteRenderer spr;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        currentPoint = B.position;
    }

    private void Update()
    {
        if (transform.position == A.position)
        {
            currentPoint = B.position;
            spr.flipX = false;
        }
        else if (transform.position == B.position)
        {
            currentPoint = A.position;
            spr.flipX = true;
        }


        transform.position = Vector3.MoveTowards(transform.position, currentPoint, speed*Time.deltaTime);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.KillPlayer();  
        }
    }
}
