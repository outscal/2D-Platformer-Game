using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform position1;
    [SerializeField] private Transform position2;
    [SerializeField] private float enemySpeed;

    private bool isPos1 = true;
    private Vector2 enemyScale;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().ReduceHealth();
        }
    }

    void Start()
    {
        transform.position = position1.position;
        GetComponent<Animator>().SetBool("IsWalk", true);
    }

    void Update()
    {
        ToFroMotion();
    }

    void ToFroMotion()
    {
        if (transform.position == position2.position)
        {
            isPos1 = false;
        }

        if (transform.position == position1.position)
        {
            isPos1 = true;
        }

        if (isPos1 == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, position2.position, enemySpeed * Time.deltaTime);
            enemyScale.x = Mathf.Abs(enemyScale.x);
            transform.localScale = enemyScale;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, position1.position, enemySpeed * Time.deltaTime);
            enemyScale.x = -1f * Mathf.Abs(enemyScale.x);
            transform.localScale = enemyScale;
        }
    }
}
