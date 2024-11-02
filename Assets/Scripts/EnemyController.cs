using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private PlayerController playerController;

    [SerializeField] private float speed;
    [SerializeField] private Transform[] waypoints;
    //private Transform targetPosition;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerController = FindObjectOfType<PlayerController>();
        }
        else
        {
            Debug.LogWarning("Player object not found!");
        }

        /*if (waypoints.Length > 0)
        {
            targetPosition = waypoints[currentWaypointIndex]; // Initialize targetPosition
        }*/
    }

    void Update()
    {
        ShowDebugging();
        HandleMovement();
        HandleAnimation();
    }

    private void HandleMovement()
    {
        MoveTowardsWaypoint();
    }

    private void HandleAnimation()
    {
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        if (targetWaypoint.position.x < transform.position.x)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        else
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    private void MoveTowardsWaypoint()
    {
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        //targetPosition.position = targetWaypoint.position;

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;

            // Loop back to the first waypoint if we're at the last one
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;  // Reset to loop
            }
        }
    }

    private void ShowDebugging()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is dead");
            playerController.KillPlayer();
        }
    }
}
