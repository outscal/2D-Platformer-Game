using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject maincam;
    public float parallaxeff;

    private void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float temp = (maincam.transform.position.x * (1 - parallaxeff));
        float dist = (maincam.transform.position.x * parallaxeff );

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if(temp > startpos+length)
        {
            startpos += length;
        }
        else if(temp < startpos+length)
        {
            startpos -= length;
        }

    }
}
