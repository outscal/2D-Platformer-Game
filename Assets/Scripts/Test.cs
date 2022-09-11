using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake called");    
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable called");
    }

    void Start()
    {
        Debug.Log("Start called");
    }

    private void FixedUpdate()
    {
        Debug.Log("Fixed Update called");
    }

    void Update()
    {
        Debug.Log("Update called");
    }

    private void LateUpdate()
    {
        Debug.Log("Late Update called");
    }

}
