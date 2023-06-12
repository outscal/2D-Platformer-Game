using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed;
    private bool movingCorrect;
    public float rayDist;

    public Transform groundDetect;

     /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundCheck = Physics2D.Raycast(groundDetect.position,Vector2.down , rayDist);

        if(groundCheck.collider == false)
        {
            if(movingCorrect == true)
            {
                transform.eulerAngles = new Vector3 ( 0 , -180 , 0);
                movingCorrect = false;
            }

            else
            {
                transform.eulerAngles = new Vector3 (0,0,0);
                movingCorrect = true;
            }
        }     
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.Playerkill();
            Destroy(gameObject);
        }
    }
}
