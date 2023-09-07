using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    public Vector3 offset = new Vector3(0, 2, -10);
    private void LateUpdate()
    {
        GameObject who = GameObject.FindGameObjectWithTag("Player");
        target = who.transform;
        transform.position = target.position + offset;
    }
}
