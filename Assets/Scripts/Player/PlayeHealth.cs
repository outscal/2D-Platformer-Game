using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeHealth : MonoBehaviour
{
    private int  maxHealth=3;
    private int health;
    public GameObject[] GameHearts;
    private int initialHealthvalue = 2;
    private int healthCount;

    public bool isAlive = true;
    void Start()
    {
        healthCount = initialHealthvalue;
        health = maxHealth;
    }

 

    public void Playerdamage(int damageAmount)

    {
       

        if (healthCount <= 0)
        {
            PlayerDied();
        }
        else
        {
           

            HealthDecrease(damageAmount);

        }


    }


   public void  HealthDecrease(int healthValue)
    {

        GameHearts[healthCount].SetActive(false);
        healthCount += healthValue;
    }


    public void PlayerDied()
    {
        isAlive = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
