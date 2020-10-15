using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float _enemySpeed = 2.0f; 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject?.GetComponent<Player>();
        if (player != null)
        {
            
            player.UpdateLives();
        }
        if (collision.gameObject.name == "EndMarker")
        {
            
            transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);

        }
    }


    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime);

    }

}
