using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] private Animator keyAnimator;
    [SerializeField] private float keyFadeDuration = 1f;
    private BoxCollider2D bc2d;

    private void Start()
    {
        keyAnimator = GetComponent<Animator>();
        keyAnimator.SetBool("KeyCollected", false);
        bc2d= GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            bc2d.enabled = false; // While playing key fade animation, it should not increase player score
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.CollectKey();
            keyAnimator.SetBool("KeyCollected", true);
            Invoke(nameof(DestroyGameObject), keyFadeDuration);
        }
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
