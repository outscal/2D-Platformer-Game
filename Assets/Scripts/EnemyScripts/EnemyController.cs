
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform patrolPointBegin;
    public Transform patrolPointEnd;
    public float movementSpeed;
    public bool bIsGoingLeft = true;
    public float coolDown = 1f;
    public float currentAttackTime = 0f;
    public float damage;
    public Animator anim;
    private bool isTouchingPlayer;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = patrolPointBegin.position; //spawn
        spriteRenderer.flipX = bIsGoingLeft; // face the end spawn point location
        movementSpeed = 1f;
        damage = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    private void Patrol()
    {   
        // Assumption: end point is always at the right,
        // so is player walking towards begin point?
        Vector3 directionTranslation = (bIsGoingLeft) ? -transform.right : transform.right;
        directionTranslation *= Time.deltaTime * movementSpeed;
        transform.Translate(directionTranslation);
        if(Vector2.Distance(transform.position, patrolPointEnd.position) < 1) //has reached end point
        {
            bIsGoingLeft = true; 
            spriteRenderer.flipX = bIsGoingLeft; // turn towards left
        }
        if (Vector2.Distance(transform.position, patrolPointBegin.position) < 1)
        {
            bIsGoingLeft = false;
            spriteRenderer.flipX = bIsGoingLeft; // turn towards right
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            
            isTouchingPlayer = true;
            anim.SetBool("IsTouchingPlayer", isTouchingPlayer);
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Touching another enemy!");
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            
            isTouchingPlayer = false;
            anim.SetBool("IsTouchingPlayer", isTouchingPlayer);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            if (currentAttackTime < coolDown)
            {
                currentAttackTime += Time.deltaTime;
            }
            else
            {
                collision.gameObject.GetComponent<PlayerController>().DecreaseHealth(damage);
                currentAttackTime = 0;
            }
            
        }
    }

}
