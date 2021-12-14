using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;
    public Transform groundDetection;
    public float distance;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0 , -180 , 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0 , 0 , 0);
                movingRight = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            Player_controller.health -= 1;
        }
       // if (collision.gameObject.GetComponent<Player_controller>() != null)
       // {
        //    Player_controller playercontroller = collision.gameObject.GetComponent<Player_controller>();
        //    playercontroller.KillPlayer();
            
       // }
    }
}
