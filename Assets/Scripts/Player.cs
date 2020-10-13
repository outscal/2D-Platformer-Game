using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ScoreController scoreController; 
    public Vector3 originalPos; 
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
    public void OnDeath()
    {

        Debug.Log(" Player has died");
        // reset player position 
        PlayerInit(); 


    }

    internal void PickUpKey()
    {
        Debug.Log("Player pickedup key");
        scoreController.IncrementScore(10); 

    }


    public void PlayerInit()
    {
        transform.position = originalPos;

    }
}
