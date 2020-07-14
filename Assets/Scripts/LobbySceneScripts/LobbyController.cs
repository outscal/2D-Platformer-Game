using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public string levelName;
    private void Awake()
    {
        playButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    
    private void StartGame()
    {
        SceneManager.LoadScene(levelName);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
