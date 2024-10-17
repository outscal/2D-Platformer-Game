using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    private TextMeshProUGUI healthText;
    private int maxHealth = 3;
    private int currentHealth;

    private void Awake()
    {
        healthText = GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component
    }

    private void Start()
    {
        currentHealth = maxHealth; // Initialize the player's health to maxHealth
        RefreshUI();
    }

    // Call this method to reduce the player's health
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Decrease health by damage amount

        if (currentHealth <= 0)
        {
            PlayerDies();
        }
        else
        {
            RefreshUI(); // Update the health display if the player is still alive
        }
    }

    private void PlayerDies()
    {
        Debug.Log("Player died! Reloading scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene when the player dies
    }

    private void RefreshUI()
    {
        healthText.text = "Health: " + currentHealth; // Update the health text
    }
}
