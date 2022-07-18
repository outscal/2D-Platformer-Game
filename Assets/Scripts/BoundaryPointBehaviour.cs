using UnityEngine;

public class BoundaryPointBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>() != null)
        {
            //change enemy scale.x by -1
            collision.gameObject.GetComponent<EnemyController>().TurnEnemy();
        }
    }
}
