using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameOverController : MonoBehaviour
{
    public Button restartButton;
    public Button quitButton;

    public void Awake()
    {
        restartButton.onClick.AddListener(ReloadLevel);
        quitButton.onClick.AddListener(QuitGame);
    }
    private void QuitGame()
    {
        // Application.Quit will not work inside unity editor
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void LoadGameOverUI()
    {
        gameObject.SetActive(true);
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
