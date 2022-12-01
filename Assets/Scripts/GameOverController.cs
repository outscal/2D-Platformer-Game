using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button quitButton;
    private void Awake()
    {
       restartButton.onClick.AddListener(ReloadLevel);
       quitButton.onClick.AddListener(LoadLobbyScene);
    }

    private void LoadLobbyScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ActivateGameOverPanel()
    {
        gameObject.SetActive(true);
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
