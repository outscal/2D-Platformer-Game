using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject target;
    public Vector3 offset = new Vector3(0, 2, -10);

    private void Start()
    {
        
    }
    private void LateUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        transform.position = target.transform.position + offset;
    }
}
