using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed;
    public float RayDistance;

    public bool moveRight = true;

    public Transform groundDetection;
    public LivesController lifeController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifeController.LoseLife();
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);

        RaycastHit2D GroundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, RayDistance);
        if(!GroundInfo.collider)
        {
            if(moveRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
            
        }
    }

}
