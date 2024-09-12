using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpController : MonoBehaviour
{
    public Animator jumpAnimator;

    void Start()
    {
        jumpAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown("w"))
        {
            jumpAnimator.Play("Player_Jump");
        }
    }
}
