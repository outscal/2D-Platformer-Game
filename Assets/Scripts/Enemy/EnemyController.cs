using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    const string LEFT = "left";
    const string RIGHT = "right";

    private Rigidbody2D EnemyBody;
    private Vector3 baseScale;
    string facingDirection;

    [SerializeField] private Transform castPos;
    [SerializeField] private float damage;
    public float castDist = 0.5f; 
    public float moveSpeed = 5f;

    private void Awake()
    {
        Debug.Log("Player controller awake");
    }

    // Start is called before the first frame update
    private void Start()
    {
        EnemyBody = gameObject.GetComponent<Rigidbody2D>();
        baseScale = transform.localScale;
        facingDirection = RIGHT;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float vX = moveSpeed;

        if (facingDirection == LEFT)
        {
            vX = -moveSpeed;
        }

        EnemyBody.velocity = new Vector2(vX, EnemyBody.velocity.y);

        if (IsNearEdge() || IsHittingWall())
        {
            if (facingDirection == LEFT)
            {
                ChangeFacingDirection(RIGHT);
            }
            else if (facingDirection == RIGHT)
            {
                ChangeFacingDirection(LEFT);
            }
        }
    }

    bool IsNearEdge()
    {
        bool val = true;

        Vector2 targetPos = castPos.position;
        targetPos.y -= castDist;

        Debug.DrawLine(castPos.position, targetPos, Color.red);

        if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Platform")))
        {
            val = false;
        }
        else
        {
            val = true;
        }

        return val;
    }

    bool IsHittingWall()
    {
        bool val = false;

        Vector2 targetPos = castPos.position;

        if (facingDirection == RIGHT)
        {
            targetPos.x += castDist;
        }
        else if (facingDirection == LEFT)
        {
            targetPos.x -= castDist;
        }
        Debug.DrawLine(castPos.position, targetPos, Color.green);

        if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Platform")))
        {
            val = true;
        }
        else
        {
            val = false;
        }
        return val;
    }

    private void ChangeFacingDirection(string newDirection)
    {
        Vector3 newScale = baseScale;
        if(newDirection == LEFT)
        {
            newScale.x = -baseScale.x;
        }
        else if (newDirection == RIGHT)
        {
            newScale.x = baseScale.x;
        }

        transform.localScale = newScale;

        facingDirection = newDirection;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        HealthController healthController = collision.gameObject.GetComponent<HealthController>();

        if(playerController != null)
        {
                healthController.TakeDamage(damage);
            
        }
    }

}
