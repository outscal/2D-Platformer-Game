using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemyRotate : MonoBehaviour
{
    public EnemyController enemyController;
    bool isGrounded=true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            {
                isGrounded = true;
            }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = false;
        } 
    }
    private void Update()
    {
        if (!isGrounded)
        {
            enemyController.MovementFlip();
        }
    }
}

