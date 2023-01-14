using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected PlayerController pController;

    private void Awake()
    {
        pController = GameObject.Find("Player").GetComponent<PlayerController>();
    
    }
    
}
