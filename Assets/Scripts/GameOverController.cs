using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        restartButton = GetComponentInChildren<Button>();
        gameObject.SetActive(false);
        restartButton.onClick.AddListener(ReloadLevel);
        quitButton.onClick.AddListener(ExitGame);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
    }

    private void ReturnToMainMenu()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void PlayerDied()
    {
        SoundManager.Instance.Play(Sounds.PlayerDeath);
        gameObject.SetActive(true);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
