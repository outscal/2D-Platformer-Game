using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public int health { get; private set; }
    public int maxHealth;

    public Sprite heart;
    public Image[] hearts;

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        playerController= GetComponent<PlayerController>();
    }

    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
        else
        {
            playerController.KillPlayer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Condition to fill the heart as per the current health of player
            if (i < health)
            {
                hearts[i].color = Color.red;
            }
            else
            {
                hearts[i].color = Color.black;
            }
            // Condition to initialize the heart symbols according to the max health
            if (i < maxHealth)
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
