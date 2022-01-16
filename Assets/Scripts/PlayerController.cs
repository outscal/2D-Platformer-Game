using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float speed = Input.GetAxisRaw("Horizontal");

        if (speed>0)
        {
            anim.SetFloat("Speed", speed);
        }

        else if (speed<0)
        {
            anim.SetFloat("-Speed", speed);
        }

        else
        {


        }
        
    }
}
