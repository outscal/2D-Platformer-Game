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
    private const string HealthKey = "PlayerHealth";

    public GameOverController gameOverController;

    private void Awake()
    {
        

        healthText = GetComponent<TextMeshProUGUI>();
        LoadHealth();
    }

    private void Start()
    {
        RefreshUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            PlayerDies();
        }
        else
        {
            SaveHealth(); // Save health to PlayerPrefs
            RefreshUI();
        }
    }

    private void SaveHealth()
    {
        PlayerPrefs.SetInt(HealthKey, currentHealth);
        PlayerPrefs.Save();
    }

    private void LoadHealth()
    {
        currentHealth = PlayerPrefs.GetInt(HealthKey, maxHealth); // Load current health
    }

    private void PlayerDies()
    {
        Debug.Log("Player died! Reloading scene...");
        gameOverController.ShowGameOver(); // Show Game Over UI
        gameObject.SetActive(false);
    }

    private void RefreshUI()
    {
        healthText.text = "Health: " + currentHealth; // Update the health text
    }


    public void ResetPlayerData()
    {
        PlayerPrefs.DeleteKey("PlayerScore");
        PlayerPrefs.DeleteKey("PlayerHealth");
        PlayerPrefs.Save();
    }
   
}
