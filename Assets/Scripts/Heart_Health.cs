using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Heart_Health : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int numOfHearts;
    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;
    [SerializeField] GameObject player;  // Reference to the player GameObject

    [SerializeField] GameOverController gameOverController;

    // Method to reduce health
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;

        UpdateHearts();

        
        if (health <= 0)
        {
            gameOverController.PlayerDied();
            
        }
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = i < health ? fullHeart : emptyHeart;
            hearts[i].enabled = i < numOfHearts;
        }
    }



    void Update()
    {
        if (health > numOfHearts) health = numOfHearts;
        UpdateHearts();
    }
}
