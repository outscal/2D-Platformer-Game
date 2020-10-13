using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Player : MonoBehaviour
{
    public ScoreController scoreController;
    public GameOverController gameOverController; 
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
        gameOverController.OnGameOver();
       
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
