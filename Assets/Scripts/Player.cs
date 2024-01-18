using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Transform GameStartLocation;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is a collectible item
        if (other.CompareTag("Collectible"))
        {
            // Increase the score
            score++;

            // Update the TextMeshPro text element with the new score
            UpdateScoreText();

            // Destroy the collectible item
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            OnTakeDamage();
        }
    }
    public int GetScore()
    {
        return score;
    }
    public void SetScoreText(int score)
    {
        this.score = score;
    }
    private void UpdateScoreText()
    {
        
        if (scoreText != null)
        {
            
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogWarning("TextMeshPro component not assigned to the player script.");
        }
    }

    public void OnTakeDamage()
    {
        if(health > 1)
        {
            health--;
            healthText.text = "Health: " + health.ToString();

            Debug.Log("Player takes damage");
            this.gameObject.transform.position = GameStartLocation.position;
        }
        else
        {
            health--;
            healthText.text = "Health: " + health.ToString();
            Destroy(gameObject);
            Debug.Log("player has died");

            SceneManager.LoadScene("GameOverScreen");
        }
    }
}
