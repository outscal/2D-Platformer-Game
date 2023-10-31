 using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField]
    private Transform[] PatrollingPoint;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private int enemyDamage;
    [SerializeField]
    private int enemyHealth;
    private Animator anim;
    private Transform Currenpoint;
    private void Start()
    {        
        anim = GetComponent<Animator>();
        Currenpoint = PatrollingPoint[0].transform;
        anim.SetBool("IsRunning", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerController playerController = collision.gameObject.GetComponent<playerController>();
        if (playerController != null)
        {
            SoundManager.Instance.LowVolSFXSounds(SoundTypes.Hurt);
            Debug.Log("collsion with enemy");
            playerController.Instance.playerHealth = playerController.Instance.playerHealth - enemyDamage;
            //collision dmg with player
            enemyHealth -= 34;
            playerController.Instance.ThrowbackFromEnemycollision();
            UI_Manager.Instance.UpdatehealthOnUI();
            //instead of doing it every frame in Update Checking if player is dead after colliding with our enenmy
            playerController.Instance.PlayerDied();
        }
    }

    private void EnemyDied()
    {
        if(enemyHealth <= 0)
        {
            SoundManager.Instance.LowVolSFXSounds(SoundTypes.EnemyDeath);
            Destroy(this.gameObject);
        }
    }
    private void ThrowbackFromPlayerCollision()
    {
        Vector3 pos = transform.position;
        pos.x += 3f;
        transform.position = pos;
    }
    // moving player towrds the next Patrolling point CP= current point TP = To next point
    private void Patrolling(int CP, int TP)
    {
        if(Currenpoint == PatrollingPoint[CP])
        {
            // move towrds = from poistion a to position b with what speed 
            transform.position = Vector2.MoveTowards(transform.position, PatrollingPoint[CP].transform.position, Speed*Time.deltaTime);
            // distance = distance btw pointa and point b (using transform)  
            if (Vector2.Distance(transform.position, PatrollingPoint[CP].transform.position)<0.2f)
            {
                flip();
                Currenpoint = PatrollingPoint[TP];
            }
        }
    }

    private void flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    //drawing sphere gizmos on patrolling points and a line btw them 
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PatrollingPoint[0].position, 0.5f);
        Gizmos.DrawWireSphere(PatrollingPoint[1].position, 0.5f);
        Gizmos.DrawLine(PatrollingPoint[0].position, PatrollingPoint[1].position);
    }

    private void Update()
    {
        Patrolling(0,1);
        Patrolling(1, 0);
        EnemyDied();
    }
}
