using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private float direction = 1.0f;

    private void Update()
    {
        EnemyMovement();
    }
    private void EnemyMovement()
    {
        Vector2 position = transform.position;
        position.x += direction * speed * Time.deltaTime;
        transform.position = position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("collided");
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.killPlayer();
        }
    }
    public void ChangeDirection()
    {
        direction = -direction;
        Vector2 scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;
    }
}
