using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [Header("Patrol Settings")]
    [SerializeField] private float patrolSpeed = 2f;
    [SerializeField] private Vector3 targetPoint;
    [SerializeField] private Vector3 pointB;
    [SerializeField] private Vector3 pointA;

    [Header("Components")]
    [SerializeField] private Enemy_Anim enemyAnim;

    private void Start()
    {
        SetPatrolPoints();
    }

    private void Update()
    {
        PatrolBetweenPoint();
    }

    private void SetPatrolPoints()
    {
        transform.position = pointA;
        targetPoint = pointB;
    }

    private void PatrolBetweenPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, patrolSpeed * Time.deltaTime);

        float direction = targetPoint.x - transform.position.x;
        transform.localScale = new Vector3(Mathf.Sign(direction) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        enemyAnim.PlayWalkAnimation(true); 

        if (transform.position == targetPoint)
        {
            targetPoint = (targetPoint == pointA) ? pointB : pointA;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealthSystem playerHealth = collision.GetComponent<PlayerHealthSystem>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
                Debug.Log("Player Got hit");
            }
        }
    }
}
