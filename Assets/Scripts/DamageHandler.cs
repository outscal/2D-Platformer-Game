using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour
{
    public float fallDamageThreshold = -10f;
    private float lastFallSpeed;
    private Rigidbody2D rb;
    private HealthManager healthManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthManager = GetComponent<HealthManager>();
    }

    void FixedUpdate()
    {
        if (!GetComponent<PlayerController>().isGrounded && rb.velocity.y < 0)
        {
            lastFallSpeed = rb.velocity.y;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && lastFallSpeed <= fallDamageThreshold)
        {
            healthManager.TakeDamage(1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            healthManager.TakeDamage(1);
        }
    }
}
