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
        quitButton.onClick.AddListener(ReloadLobbyScene);
    }
    public void ActivateGameOverPanel()
    {
        gameObject.SetActive(true);
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ReloadLobbyScene()
    {
        SceneManager.LoadScene(0);
    }
}
