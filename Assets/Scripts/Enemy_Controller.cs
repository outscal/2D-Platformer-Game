using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public float speed = 2f;
    public float minX;
    public float maxX;
   

    void Update()
    {
        EnemyHorizontalMovemet();
    }


    //Enemy Horizonatl movemet
    void EnemyHorizontalMovemet()
    {
        Vector2 position = transform.position;
        Vector2 scale = transform.localScale;
        // Move the object
        position.x += speed * Time.deltaTime;

        // Check if the object has reached maxX or minX
        if (position.x >= maxX || position.x <= minX)
        {
            // Reverse the direction of movement
            speed = -speed;

            // Flip the scale of the object to face the opposite direction
            scale.x = -scale.x;
        }

        transform.position = new Vector2(position.x, 0);
        transform.localScale = scale;
    }

    //Player Death animation after dying
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player_Controller playerController = collision.gameObject.GetComponent<Player_Controller>();

        if (playerController != null)
        {

            playerController.playerDeath();
            speed = 0;
        }
    }

}
