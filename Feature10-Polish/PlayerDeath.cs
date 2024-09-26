using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Animator An;
    private Rigidbody2D Rd;

    private void Start()
    {
        An = GetComponent<Animator>();
        Rd = GetComponent<Rigidbody2D>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Die();
        }
    }

    public void Die()
    {
        An.SetTrigger("Death");
        Rd.bodyType = RigidbodyType2D.Static;
    }
}


