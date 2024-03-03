using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;
   
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));

        Vector3 scale = gameObject.transform.localScale;
        if (speed < 0f)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        } else if(speed > 0f)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        gameObject.transform.localScale = scale;
    }
}
