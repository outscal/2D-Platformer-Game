using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private Animator animator;

    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(xAxis));

        Vector3 scale = transform.localScale;

        if (xAxis <0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if(xAxis > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }
}
