using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public Animator keyAnimator;
    public float keyFadeDuration = 1f;

    private void Start()
    {
        keyAnimator = GetComponent<Animator>();
        keyAnimator.SetBool("KeyCollected", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
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
