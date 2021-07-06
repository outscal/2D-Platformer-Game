using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elle2D
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] float distance = 8f;
        void Update()
        {

            float x = transform.position.x;
            float y = Mathf.Sin(Time.time) * distance;
            float z = transform.position.z;
            transform.position = new Vector3(x, y, z);
        }
    }
}