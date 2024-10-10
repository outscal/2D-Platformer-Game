using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        float speed = Input.GetAxis("Horizontal");
        Vector3 scale = transform.localScale;

        animator.SetFloat("Speed",Mathf.Abs(speed));

        if(speed < 0 )
            scale.x = -1f * Mathf.Abs(scale.x);

        else if (speed > 0 )
            scale.x = Mathf.Abs(scale.x);

        transform.localScale = scale;
    }

}
