using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Button restartButton; // Reference to the restart button
    [SerializeField] private Button lobby;
    [SerializeField] private TextMeshProUGUI scoreText; // Optional: display score on Game Over screen

    private void Start()
    {
        // Ensure the Game Over UI is not visible at the start
        gameOverUI.SetActive(false);

        // Add listener to the restart button
        restartButton.onClick.AddListener(RestartGame);
        lobby.onClick.AddListener(Lobby);
    }

    public void ShowGameOver()
    {
        SoundController.Instance.PlayMusic(Sounds.PlayerDeath);
        gameOverUI.SetActive(true); // Show Game Over UI
        Time.timeScale = 0f;
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    private void Lobby()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0, LoadSceneMode.Single); //reload lobby
        
    }
}
