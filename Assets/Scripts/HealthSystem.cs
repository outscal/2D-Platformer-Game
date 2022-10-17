using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    public int playerHealth;
    [SerializeField]
    private Image[] _hearts;
    public GameObject gameOverMenu;

    private void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
     
        if(playerHealth <= 0)
        {
            gameOverMenu.SetActive(true);
        }
        else
        {
           
            for (int i = 0; i < _hearts.Length; i++)
            {
                if (i < playerHealth)
                {
                    _hearts[i].color = Color.red;
                }
                else if(i >= playerHealth)
                {
                    _hearts[i].color = Color.black;
                }
                
            }
        }
       
    }
}
