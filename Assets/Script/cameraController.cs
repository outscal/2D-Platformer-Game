using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 Offset;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = target.position - Offset;
    }
}
