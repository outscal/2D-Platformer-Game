using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplayController : MonoBehaviour
{
    public int playerHealth;
    public int playerMaxHealth;
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;
    public PlayerHealthController playerHealthController;

    void Update()
    {
        //making sure that player health and maxHealth values matches playerHealthController script
        playerHealth = playerHealthController.playerHealth;
        playerMaxHealth = playerHealthController.maxHealth; 

        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < playerHealth)                       // This loop will check each heart to see if  
            {                                          // its full or empty
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < playerMaxHealth)                    // Checks if heart value is less than max health
            {                                          // then display equivalent no. of hearts
                hearts[i].enabled = true;
            }
            else
            {
                // Turns off hearts that should not be active
                hearts[i].enabled = false;
            }
        }
    }
}
