using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossMovingPlatform : MonoBehaviour
{
    void Update()
    {

        float x = -transform.position.y;
        float y = Mathf.Sin(Time.time) * 2.5f;

        // float x = Mathf.Sin(Time.time) * 2f;
        // float y = transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }
}
