using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    void Update()
    {

        float x = transform.position.x;
        float y = Mathf.Sin(Time.time) * 8f;

        // float x = Mathf.Sin(Time.time) * 2f;
        // float y = transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }
}
