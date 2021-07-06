using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elle2D
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] bool moveRight;
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
            if (moveRight)
            {
                transform.Translate(2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(1.25f, 1.25f);
            }
            else
            {

                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(-1.25f, 1.25f);
            }
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
            yield return new WaitForSeconds(0.5f);
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