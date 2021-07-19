using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private void Awake()
    {
        Debug.Log("Player Controller awake");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision: " + collision.gameObject.name);
    }

    private void Update()
    {
        float Speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(Speed));

        Vector3 scale = transform.localScale;
        if (Speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        } else if (Speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
    }

