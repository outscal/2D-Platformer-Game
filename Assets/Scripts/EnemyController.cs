using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  
  public GameObject pointA;
  public GameObject pointB;
  private Rigidbody2D rb2d;
  private Animator anim;
  private Transform currentPoint;

 [SerializeField] float speed;



  private void Start() 
  {
    rb2d = GetComponent<Rigidbody2D>();
    anim= GetComponent<Animator>();
    currentPoint = pointB.transform;
    anim.SetBool ("Run", true);
    speed = 1f;
  }

 private void Update()
 {
    Vector2 point = currentPoint.position - transform.position;
    if (currentPoint == pointB.transform)
    {
        rb2d.velocity = new Vector2 (speed, 0);
    }
     else
      {
       rb2d.velocity = new Vector2 (-speed, 0);
     }


   if (Vector2.Distance(transform.position , currentPoint.position) < 1f && currentPoint == pointB.transform)
   {
     flip();
     currentPoint = pointA.transform;
   }

  if (Vector2.Distance(transform.position , currentPoint.position) < 1f && currentPoint == pointA.transform)
  {
    flip();
    currentPoint = pointB.transform;
  }

  }


private void flip()
{
 Vector3 localscale = transform.localScale;
 localscale.x *= -1f;
 transform.localScale = localscale;
}


private void OnDrawGizmos() 
{
    Gizmos.DrawWireSphere(pointA.transform.position, 1f);
    Gizmos.DrawWireSphere(pointB.transform.position, 1f);
    Gizmos.DrawLine (pointA.transform.position, pointB.transform.position);
}



    //Kill
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null )
        {
               PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
               playerController.KillPlayer();
              // Destroy (gameObject);
        }
    }
}
