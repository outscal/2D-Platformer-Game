using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public Sprite heart;
    public Image[] hearts;

    public PlayerHealthController playerHealthController;

    // Start is called before the first frame update
    void Start()
    {
        health = playerHealthController.health;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Condition to fill the heart as per the current health of player
            if(i < health)
            {
                hearts[i].color = Color.red;
            }
            else
            {
                hearts[i].color = Color.black;
            }
            // Condition to initialize the heart symbols according to the max health
            if(i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;  
            }
        }
    }
}
