using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform leftPosition;
    [SerializeField] private Transform rightPosition;
    [SerializeField] private float enemySpeed;

    private bool isWalk = true;
    private bool isLeft = true;
    private Vector2 enemyScale;

    void Start()
    {
        transform.position = leftPosition.position;
        enemyScale = transform.localScale;
        GetComponent<Animator>().SetBool("IsWalk", true);
    }

    void Update()
    {
        if(transform.position == rightPosition.position)
        {
            isLeft = false;
        }

        if(transform.position == leftPosition.position)
        {
            isLeft = true;
        }

        ToFroMotion();
    }

    void ToFroMotion()
    {
        if (isLeft == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, rightPosition.position, enemySpeed * Time.deltaTime);
            enemyScale.x = Mathf.Abs(enemyScale.x);
            transform.localScale = enemyScale;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, leftPosition.position, enemySpeed * Time.deltaTime);
            enemyScale.x = -1f * Mathf.Abs(enemyScale.x);
            transform.localScale = enemyScale;
        }
    }
}
