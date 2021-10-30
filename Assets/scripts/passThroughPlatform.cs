using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passThroughPlatform : MonoBehaviour
{
    public Transform playerFoot;
    public Collider2D collider;
    float  distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = transform.position.y-playerFoot.position.y ;
        if(distance<0)
        {
            collider.enabled = true;
        }
        else
        {
            collider.enabled = false;
        }
        
    }
}
