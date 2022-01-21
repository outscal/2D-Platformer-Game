using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouchController : MonoBehaviour
{
    public Animator crouchAnimator;

    void Start()
    {
        crouchAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown("s"))
        {
            crouchAnimator.Play("Player_crouch");
        }
    }
}
