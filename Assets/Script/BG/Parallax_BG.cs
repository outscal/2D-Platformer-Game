using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_BG : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 LastCameraPosition;
    [SerializeField] float ParallaxEffect;
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        LastCameraPosition = cameraTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 DeltaMovement = cameraTransform.position - LastCameraPosition;
        transform.position += DeltaMovement * ParallaxEffect;
        LastCameraPosition = cameraTransform.position;  
    }
}
