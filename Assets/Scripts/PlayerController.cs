using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()    {


        float _speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(_speed));
        Vector3 scale = transform.localScale;
        if (_speed <0)
        {

            scale.x = -1f * Mathf.Abs(scale.x);

        }else if (_speed > 0)
        {

            scale.x = Mathf.Abs(scale.x);

        }
        transform.localScale = scale; 

    }
}
