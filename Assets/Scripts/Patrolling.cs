using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public float movementSpeed = 5f;

    private Transform[] patrolPoints;
    private int currentPatrolIndex;
    private bool isMoving;

    private void Start()
    {
        FindPatrolPoints();

        currentPatrolIndex = 0;
        isMoving = true;
    }

    private void FindPatrolPoints()
    {

        GameObject[] pointObjects = GameObject.FindGameObjectsWithTag("PatrolPoint");


        patrolPoints = new Transform[pointObjects.Length];

        for (int i = 0; i < pointObjects.Length; i++)
        {
            patrolPoints[i] = pointObjects[i].transform;
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            if (patrolPoints.Length > 0)
            {
                Vector3 targetPosition = patrolPoints[currentPatrolIndex].position;
                Vector3 currentPosition = transform.position;
                float distance = Vector3.Distance(currentPosition, targetPosition);

                if (distance > 0.1f) 
                {
                    Vector3 newPosition = Vector3.MoveTowards(currentPosition, targetPosition, movementSpeed * Time.deltaTime);
                    transform.position = newPosition;
                }
                else
                {

                    currentPatrolIndex++;
                    if (currentPatrolIndex >= patrolPoints.Length)
                    {
                        currentPatrolIndex = 0;
                    }
                }
            }
        }
    }
}

