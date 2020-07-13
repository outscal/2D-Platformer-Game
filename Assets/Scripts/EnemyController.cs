using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;


    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        Vector2 position = transform.position;
        position.x += speed * Time.deltaTime;
        transform.position = position;
        Debug.Log("Enemy Move");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.killPlayer();
        }
    }
}
