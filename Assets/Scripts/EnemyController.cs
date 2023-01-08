using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed;
    public int movingRight = 1;
    public GameObject groundDetector;
    public float rayDistance;
    public Animator enemyAnimator;

    private void Update()
    {
        PatrolEnemy();
    }

    private void PatrolEnemy()
    {
        enemyAnimator.SetBool("IsPatrol", true);
        transform.Translate(movingRight * Vector2.right * enemySpeed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(groundDetector.transform.position, Vector2.down, rayDistance);

        if(!hit)
        {
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            movingRight = movingRight * -1;
        }
    }
}
