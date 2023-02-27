using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    enum Work { IDLE, WALK };
    private Work _currentWork = Work.IDLE;
    private int _targetPoint = 1;

    public GameObject[] patrolPoints;
    public float tWait = 1;
    public float vWalk = 1;

    private Animator _anim;
    private SpriteRenderer _sprite;

    private void Awake() {
        _anim = gameObject.GetComponent<Animator>();
        _sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (_currentWork == Work.IDLE) {
            Invoke("StartWalking", tWait);

        } else if (_currentWork == Work.WALK) {
            Vector3 p = transform.position;
            Vector3 dx = patrolPoints[_targetPoint].transform.position - p;

            if (dx.x > 0) { _sprite.flipX = false; } else if (dx.x < 0) { _sprite.flipX = true; }

            if (dx.magnitude < 0.1) {
                transform.position = patrolPoints[_targetPoint].transform.position;
                StopWalking();

            } else {
                p += Vector3.Normalize(dx) * vWalk * Time.deltaTime;
                transform.position = p;
            }
        }
    }

    private void StartWalking() {
        _currentWork = Work.WALK;
        _anim.SetBool("walking", true);
    }

    private void StopWalking() {
        _currentWork = Work.IDLE;
        _anim.SetBool("walking", false);

        _targetPoint = (_targetPoint + 1) % patrolPoints.Length;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerController>().Damage();

            _anim.SetTrigger("attack");
        }
    }

}
