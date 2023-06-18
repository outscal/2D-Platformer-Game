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

    private void Awake()
    {
        enemyAnimator.SetBool("IsPatrol", true);
    }

    private void Update()
    {
        PatrolEnemy();
    }

    private void PatrolEnemy()
    {
        transform.Translate(movingRight * Vector2.right * enemySpeed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(groundDetector.transform.position, Vector2.down, rayDistance);

        if(!hit)
        {
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            movingRight = movingRight * -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent<PlayerController>(out PlayerController controller))
        {
            controller.DecreaseHealth();
        }
    }
}
