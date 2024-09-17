using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera camera;
    [SerializeField] GameObject player;
    [SerializeField] Vector3 camera_position;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame

    private void LateUpdate()
    {
        if (camera != null)
        {
            camera.transform.position = player.transform.position + camera_position; 

        }
    }
}
