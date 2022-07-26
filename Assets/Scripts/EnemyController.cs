using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeedX = 1.25f;
    private Animator enemyAnimator;

    private void Start()
    {
        enemyAnimator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        MoveEnemy();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
            collision.gameObject.GetComponent<PlayerController>().DamagePlayer();

        if(collision.gameObject.tag == "BoundaryLine")
            TurnEnemy();
    }

    public void TurnEnemy()
    {
        Vector3 scale = transform.localScale;
        scale.x = -1f * scale.x;
        transform.localScale = scale;
    }

    //moves on x axis at a constant rate
    private void MoveEnemy()
    {
        PlayMovementAnimations();

        Vector3 position = transform.position;
        position.x += enemySpeedX * transform.localScale.x * Time.deltaTime;
        transform.position = position;
    }

    private void PlayMovementAnimations()
    {
        if (enemySpeedX > 0)
            enemyAnimator.SetBool("isEnemyMoving", true);
        else
            enemyAnimator.SetBool("isEnemyMoving", false);
    }
}
