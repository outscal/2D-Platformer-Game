using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 3;
    private int currentHealth;
    private TextMeshProUGUI healthText;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        currentHealth--;
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthText()
    {
        healthText.text = "Health: " + currentHealth + "/" + maxHealth;
    }

    private void Die()
    {
        // Play death animation or effect
        Debug.Log("Player died!");
        // Reload the level
        ReloadLevel();
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
