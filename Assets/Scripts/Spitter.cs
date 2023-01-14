using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spitter :Enemy
{
    private Animator anim;
    private SpriteRenderer sRenderer;
    //private SpriteRenderer sRenderer;

    [SerializeField]
    private Transform _pointA, _pointB;
    private Vector3 _currentTarget;

    [SerializeField] private float _speed;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Patroling();
    }

    void Patroling()
    {
        if(_currentTarget  == _pointB.position)
        {
            sRenderer.flipX = false;
        }
        else if(_currentTarget == _pointA.position)
        {
            sRenderer.flipX = true;
        }

        if(transform.position == _pointA.position)
        {
            _currentTarget = _pointB.position;
        }
        else if(transform.position == _pointB.position)
        {
            _currentTarget = _pointA.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pController.Damage();
        }
    }
}
