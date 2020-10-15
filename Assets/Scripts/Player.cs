using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Player : MonoBehaviour
{
    public ScoreController scoreController;
    public GameOverController gameOverController;
    public HealthUIController healthUIController; 
    public Vector3 originalPos;
    int lives; 

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        PlayerInit();
    }


    public void OnDeath()
    {
        Debug.Log(" Player has died");
        gameOverController.OnGameOver();
       
    }

    public void UpdateLives()
    {
        lives--;
        healthUIController.LivesDisplayUpdate(lives); 
        if (lives == 0)
        {
            OnDeath(); 
        }
    }


    internal void PickUpKey()
    {
        Debug.Log("Player pickedup key");
        scoreController.IncrementScore(10); 

    }
    public void PlayerInit()
    {

        transform.position = originalPos;
        lives = 3; 
    }

}
