using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Range(0, 10)] public float moveSpeed;
    public Animator animator;
    void Start()
    {
        
    }


    public void MovementFlip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {   
        Vector3 enemyPos = gameObject.transform.position;
        
        if(transform.localScale.x > 0.1)
        {
            enemyPos.x += moveSpeed * Time.deltaTime;

        }
        else if(transform.localScale.x < 0.1)
        {
            enemyPos.x -= moveSpeed * Time.deltaTime;
        }

        //else if(transform.rotation.y == 180)
        //{
        //  enemyPos.x -=  moveSpeed * Time.deltaTime;
        //}
        transform.position = enemyPos;
    }
}
