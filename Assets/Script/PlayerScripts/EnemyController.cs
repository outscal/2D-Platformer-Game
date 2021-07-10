using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elle2D
{
    public class EnemyController :  MonoBehaviour
    {
        [SerializeField] float speed;
        public bool moveRight;
        [SerializeField] int enemyHealth = 40;
        [SerializeField] bool idleEnemy = false;
        public Animator anim;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
                playerController.KillPlayer();
            }
        }

        private void MoveEnemy()
        {

            Vector3 scale = transform.localScale;
            if (moveRight)
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
                scale.x = 1 * Mathf.Abs(scale.x);
            }
            else
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
                scale.x = -1 * Mathf.Abs(scale.x);
            }

            transform.localScale = scale;
        }

        private void OnTriggerEnter2D(Collider2D trig)
        {
            if (trig.gameObject.CompareTag("Turn"))
            {
                if (moveRight)
                {
                    moveRight = false;
                }
                else
                {
                    moveRight = true;
                }
            }
        }

        public void TakeDamage(int damage)
        {
            enemyHealth -= damage;
            if (enemyHealth <= 0)
            {
                StartCoroutine(PlayDeadEnemy());
            }
        }

        IEnumerator PlayDeadEnemy()
        {
            anim.SetBool("Dead", true);
            idleEnemy = true;
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
        }


        void Update()
        {
            if (!idleEnemy)
            {
                MoveEnemy();
            }
        }
    }
}