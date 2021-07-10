using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elle2D
{
    //after instantiating bullet this fun will work
    public class BulletScript : MonoBehaviour
    {
        [SerializeField] float speed = 20f;
        [SerializeField] int damage = 10;
        public Rigidbody2D rb;
        public PlayerController player;

 
        void Start()
        {
            rb.velocity = transform.right * speed;
        }
        private void OnTriggerEnter2D(Collider2D collider)
        {
            EnemyController enemy = collider.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

    }
}