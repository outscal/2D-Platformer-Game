using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    public Animator animator;

    private void Update()
    {
        float Speed =  Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(Speed));

        Vector3 scale = transform.localScale;
        if (Speed < 0)
        { 
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (Speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

}
