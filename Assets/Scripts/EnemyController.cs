using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyController : MonoBehaviour
{

    //new implementation
    private bool mustPatrol;
    private bool mustTurn;
    [SerializeField]
    private float walkSpeed;
    public Transform groundCheckPos;
    public LayerMask groundLayer;

    Rigidbody2D rb2d;
    Animator _animator;
    Player_Controller playerController;
    HealthSystem healthSystem;
    
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerController = gameObject.GetComponent<Player_Controller>();
        healthSystem = gameObject.GetComponent <HealthSystem>();
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
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            // healthSystem.TakeDamage(10);
            Debug.Log("OnCollision");
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
 
}
