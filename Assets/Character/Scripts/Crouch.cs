using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("IsCrouching", true);
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("IsCrouching", false);
        }
    }
}
