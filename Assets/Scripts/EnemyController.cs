using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Enemy {
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] bool isWalkingLeft = false;
        [SerializeField] float speed;
        [SerializeField] LayerMask platformLayerMask;
        Animator animator;
        SpriteRenderer sr;
        BoxCollider2D bc2d;

        private void Awake() {
            animator = GetComponent<Animator>();
            animator.SetBool("Walk", true);
            sr = GetComponent<SpriteRenderer>();
            bc2d = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.GetComponent<PlayerController>() != null) {
                // Collided with Player
                PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
                float playerXPosition = other.gameObject.transform.position.x;
                EnemyAttack(playerXPosition);
                playerController.TakeDamage();
            }
        }
        
        private void PatrolArea() {
            // Patrol Area using Raycasts
            float extraHeight = 1f;
            RaycastHit2D raycastHitLeft = Physics2D.Raycast(new Vector2(bc2d.bounds.min.x, bc2d.bounds.center.y), Vector2.down, bc2d.bounds.extents.y + extraHeight, platformLayerMask);
            RaycastHit2D raycastHitRight = Physics2D.Raycast(new Vector2(bc2d.bounds.max.x, bc2d.bounds.center.y), Vector2.down, bc2d.bounds.extents.y + extraHeight, platformLayerMask);
            if (raycastHitLeft.collider == null) {
                isWalkingLeft = false;
            } else if (raycastHitRight.collider == null) {
                isWalkingLeft = true;
            }
        }

        private void EnemyAttack(float playerXPosition) {
            // Check if Player is on Left or Right
            isWalkingLeft = playerXPosition < transform.position.x;
            animator.SetTrigger("Attack");
        }

        private void EnemyMovement() {
            sr.flipX = isWalkingLeft;
            Vector2 position = transform.position;
            if (isWalkingLeft) {
                // Speed should be negative
                position.x += (-1 * speed * Time.deltaTime);
            } else {
                position.x += (1 * speed * Time.deltaTime);
            }
            transform.position = position;
        }

        private void Update() {
            // Patrol the Area : Look in the direction
            EnemyMovement();
            PatrolArea();
        }
    }
}
