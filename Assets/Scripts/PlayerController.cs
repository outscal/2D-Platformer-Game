using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
[SerializeField] Animator animator;

private void Update()
    { 
float sp = Input.GetAxisRaw("Horizontal");
animator.SetFloat("Speed", Mathf.Abs(sp));

Vector3 scale = transform.localScale;

if(sp<0) {
            scale.x = -1f * Mathf.Abs(scale.x);
} else if (sp > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
transform.localScale = scale;
}
}
