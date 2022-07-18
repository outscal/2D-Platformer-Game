using UnityEngine;

public class BoundaryPointBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>() != null)
        {
            //object instance created
            EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
            enemyController.TurnEnemy();
        }
    }
}
