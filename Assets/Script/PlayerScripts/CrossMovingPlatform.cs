using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossMovingPlatform : MonoBehaviour
{
    [SerializeField] float distance = 2.5f;
    void Update()
    {
        float x = -transform.position.y;
        float y = Mathf.Sin(Time.time) * distance;
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}
