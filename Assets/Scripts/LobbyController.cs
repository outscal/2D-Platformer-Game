using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    private void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
    }
    private void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Ended");
    }
    private void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
