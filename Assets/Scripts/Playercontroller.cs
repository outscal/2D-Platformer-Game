using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed",Mathf.Abs(speed));
        Debug.Log(speed);
        Vector2 scale = transform.localScale;
        if (speed < 0)
        {
            
            scale.x = -1.0f * Mathf.Abs(scale.x);
            
        }else if(speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            
        }
        transform.localScale = scale;

    }
}
