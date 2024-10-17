using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverUI; // The Game Over UI panel
    public Button restartButton; // Reference to the restart button
    public TextMeshProUGUI scoreText; // Optional: display score on Game Over screen

    private void Start()
    {
        // Ensure the Game Over UI is not visible at the start
        gameOverUI.SetActive(false);

        // Add listener to the restart button
        restartButton.onClick.AddListener(RestartGame);
    }

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true); // Show Game Over UI
        // Optionally display score here if you have a score system
        // scoreText.text = "Score: " + score; 
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
