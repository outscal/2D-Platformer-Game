using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void Update()
    {
        MoveEnemy();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
        }
    }

    public void TurnEnemy()
    {
        Vector3 scale = transform.localScale;
        scale.x = -1f * scale.x;
        transform.localScale = scale;
    }

    private void MoveEnemy()
    {
        Vector3 position = transform.position;
        // transform.localScale.x will give us either positive or negative value.
        position.x += 2 * transform.localScale.x * Time.deltaTime;
        transform.position = position;
    }
}
