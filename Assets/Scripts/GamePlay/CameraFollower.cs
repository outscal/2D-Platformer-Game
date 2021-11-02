using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    [SerializeField] private Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;

    private void Awake()
    {
        offset = transform.position - target.position; 
    }
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 CameraPos = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);
        transform.position = CameraPos;
    }
}
