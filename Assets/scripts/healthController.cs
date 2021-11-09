using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthController : MonoBehaviour
{
    Animator anmi;
    void Start()
    {
        anmi = gameObject.GetComponent<Animator>();
        
    }

    public void looseHeart()
    {
        anmi.SetBool("die", true);
    }
    public void gainHeart()
    {
        anmi.SetBool("die", false);
    }
}
