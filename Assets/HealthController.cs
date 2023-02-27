using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    int health;
    internal int HealthCheck()
    {
        return transform.childCount;
    }

    internal void TakeDamage()
    {
        /* for(var i = transform.childCount - 1; i >= 0; i--)
         {
             if(transform.GetChild(i).tag == "Health")
             {
                 Debug.Log("Destroyed " +i);
                 Destroy(transform.GetChild(i).gameObject);
             }


         }*/
        //Debug.Log("Destroyed " + HealthCheck());
        if(HealthCheck()>0)
        Destroy(transform.GetChild(HealthCheck()-1).gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        int i = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        health = HealthCheck();
    }
}
