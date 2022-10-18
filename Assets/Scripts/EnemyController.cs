using UnityEngine;



public class EnemyController : MonoBehaviour
{

   //Patrolling
 
    [SerializeField]
    private float walkSpeed;
    public Transform groundDetect;
    public float rayDist;
    private bool movingRight;

    [SerializeField]
    Animator _animator;
    [SerializeField]
    private HealthSystem _healthSystem;

    //Heartsystem
    public  int _enemyDamage;
    [SerializeField]



    void Update()
    {
        transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);
        RaycastHit2D groundcheck = Physics2D.Raycast(groundDetect.position, Vector2.down, rayDist);

        if(groundcheck.collider == false)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Player")
        {
           _animator.SetTrigger("Attack");
            Damage();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _animator.SetTrigger("EnemyDied");
            Destroy(this.gameObject);
        }
    }
    private void Damage()
    {
        _healthSystem.playerHealth -= _enemyDamage;
        _healthSystem.UpdateHealth();
    }
}
