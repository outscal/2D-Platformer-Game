using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Reference to Waypoints
    public List<Transform> points;
    //int value for next point index
    public int nextID = 0;
    //The Value of that applies to ID for changing
    int idChangeValue = 1;
    //Speed of movement
    public float speed = 3;
    Animator anim;
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.killPlayer();
            //Destroy(gameObject);
        }
    }

    void MoveToNextPoint()
    {
        //get the next point transform
        Transform goalPoint = points[nextID];
        //Flip the enemy to look into point direction
        if (goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
        //Move the enemy toward the goal/next point
        //anim.SetFloat("Speed", 3);
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed*Time.deltaTime);
        //anim.SetFloat("Speed", 3);

        //Check the distance b/w enemy & goal pt to trigger to trigger next point
        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            //Check if we are at the end of the line, (make the change -1)
            //2points (0,1) next == points.count(2)-1
            if (nextID == points.Count - 1)
                idChangeValue = -1;
            //Check if we are at the start of the line (make the change +1)
            if (nextID == 0)
                idChangeValue = 1;
            //Apply the change on the nextID
            nextID += idChangeValue;
          //  anim.SetFloat("Speed", 3);
        }
        
    }

    private void Start()
    {
        //anim.Play("Chomper_Idle");
      //  anim.SetFloat("Speed", 3);
    }

    private void Update()
    {
        MoveToNextPoint();
    }
}
