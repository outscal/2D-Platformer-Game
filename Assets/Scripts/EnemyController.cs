using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyController : MonoBehaviour
{

   //Patrolling
    private bool mustPatrol;
    private bool mustTurn;
    [SerializeField]
    private float walkSpeed;
    public Transform groundCheckPos;
    public LayerMask groundLayer;

    Rigidbody2D rb2d;
    [SerializeField]
    Animator _animator;
    [SerializeField]
    private HealthSystem _healthSystem;

    //Heartsystem
    public  int _enemyDamage;
    [SerializeField]
    


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
         mustPatrol = true;
    }
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }
    void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }
   
    private void Patrol()
    {
        if (mustTurn)
        {
            Flip();
        }
        rb2d.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb2d.velocity.y);
    }
    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true; 
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Player")
        {
           _animator.SetBool("Attack", true);
            Damage();
        }
    }

    private void Damage()
    {
        _healthSystem.playerHealth -= _enemyDamage;
        _healthSystem.UpdateHealth();
    }
}
