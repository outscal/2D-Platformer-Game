using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperScript : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;

    [SerializeField] private float chomperSpeed;

    private int wayPointIndex = 0;

    private void Update()
    {
        ChomperMove();
    }

    private void ChomperMove()
    {
        if(Vector2.Distance(transform.position, wayPoints[wayPointIndex].position) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoints[wayPointIndex].position, chomperSpeed);
        }
        else
        {
            if (wayPointIndex < wayPoints.Length - 1)
            {
                wayPointIndex++;
            }
            else
            {
                wayPointIndex = 0;
            }

            transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);
        }
    }
}
