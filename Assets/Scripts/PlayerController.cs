using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(speed));

        Vector3 scale = transform.localScale;
        if (speed < 0)
        {   
            scale.x = -1f * Mathf.Abs(speed);
        }
        else if(speed > 0)
        {
            scale.x = Mathf.Abs(speed);
        }
        transform.localScale = scale;
    }
}
