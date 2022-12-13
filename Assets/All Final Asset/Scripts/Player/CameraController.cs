using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float FollowSpeed;
    [SerializeField] float yoffset;
    [SerializeField] private Transform target;
void Update()
{
    Vector3 newpos = new Vector3(target.position.x,target.position.y + yoffset,-10f);
    transform.position = Vector3.Slerp(transform.position,newpos,FollowSpeed * Time.deltaTime);
}
 
}
