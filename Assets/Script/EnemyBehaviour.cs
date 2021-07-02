// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemyBehaviour : MonoBehaviour
// {
//     public Transform originPosition;
//     // public Transform originPosition2;
//     Vector2 dir = new Vector2(-1, 0);
//     public float range;
//     public float speed;
//     Rigidbody2D rb;

//     private void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//     }
//     void Update()
//     {
//         Debug.DrawRay(originPosition.position, dir * range);
//         RaycastHit2D raycastHit2D = Physics2D.Raycast(originPosition.position, dir, range);
//         // RaycastHit2D raycastHit = Physics2D.Raycast(originPosition2.position, dir, range);

//         // if (raycastHit2D)
//         // {
//         //     if (raycastHit2D.collider.tag == "Ground")
//         //     {
//         //         Debug.Log("raycastHit2D " + raycastHit2D.collider.name);
//         //         Flip();
//         //         speed *= -1;
//         //         dir *= -1;
//         //     }
//         // }

//         if (!raycastHit2D)
//         {
//             flipDirection();
//         }

//         // if (raycastHit)
//         // {
//         //     if (raycastHit.collider.tag == "Ground")
//         //     {
//         //         Debug.Log("raycastHit " + raycastHit.collider.name);
//         //         flipDirection();
//         //     }
//         // }

//     }

//     void flipDirection()
//     {
//         Flip();
//         speed *= -1;
//         dir *= -1;
//     }

//     void Flip()
//     {
//         Vector2 scale = transform.localScale;
//         scale.x = -(scale.x);
//         transform.localScale = scale;
//     }

//     void FixedUpdate()
//     {
//         rb.velocity = new Vector2(speed, rb.velocity.y);
//     }
// }