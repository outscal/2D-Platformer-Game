using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;
    PlayerController pl;
    public GameOverScripter gameOverScripter;

    public void LoseLife()
    {
        //Decrease the value of livesRemaing
        livesRemaining--;
        //Hide one of the heart image
        if (livesRemaining >-1)
        {
            lives[livesRemaining].enabled = false;
        }
        
        //If we run out of life. we Lose the game
        if(livesRemaining == 0)
        {
            Debug.Log("Die Die You Player");
             pl.Animator.SetBool("Dead", true);
            gameOverScripter.playerDied();
            pl.enabled = false;
            //gameObject.GetComponent<GameOverScripter>().playerDied();
            //  pl.Invoke("ReloadGame", 3f);
            // Destroy(gameObject);
            // throw new NotImplementedException();
        }
    }

    private void Start()
    {
        pl = gameObject.GetComponent<PlayerController>();
       // gameOverScripter = gameObject.GetComponent<GameOverScripter>();
        
    }
}
