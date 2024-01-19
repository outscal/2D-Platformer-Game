using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float range, speed;

    [SerializeField] Vector3 initialPosition;
    private bool movingRight = true;
    private Vector3 currentPosition;

    private void Start()
    {
        currentPosition = initialPosition;
    }

    void Update()
    {
        float sinValue = Mathf.Sin(Time.time * speed);
        float targetX = sinValue * range;

        currentPosition.x = targetX;
        transform.position = currentPosition + initialPosition;

       // Debug.Log($"targetX: {targetX}, position.x: {transform.position.x}, movingRight: {movingRight}");

        if (targetX >= range-0.001f && movingRight || targetX <= -range + 0.001f && !movingRight)
        {
            Flip();
            movingRight = !movingRight;
        }
    }

    private void Flip()
    {
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        //Debug.Log("flip");
    }
}
