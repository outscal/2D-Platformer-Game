using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// LobbyScene script where I've added two UI Buttons. Play/Quit Button. 
/// Clicking on Play will send you to the LevelOne of the game
/// Clicking on Quit will stop the game and quit it
/// </summary>

public class LobbyController : MonoBehaviour
{
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonQuit;
    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
        buttonQuit.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
