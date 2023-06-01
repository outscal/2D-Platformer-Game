using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button restartButton;
    public Button quiteButton;

    void Awake()
    {
        restartButton.onClick.AddListener(ReloadStartScene);
        quiteButton.onClick.AddListener(LoadLobbyScene);
    }

    public void PlayeDied()
    {
        gameObject.SetActive(true);
    }

    private void ReloadStartScene()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(1);
    }
    private void LoadLobbyScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(0);
    }
}
