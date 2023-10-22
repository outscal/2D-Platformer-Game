using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collactabe : MonoBehaviour
{
    [SerializeField] private string anim;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.Play(anim);
    }

    public void PlayCollected()
    {
        animator.Play("Fade");
    }

    public void DestroyItSelf()
    {
        Destroy(gameObject);
    }
}
