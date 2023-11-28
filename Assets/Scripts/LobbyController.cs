using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;


    private void Awake()
    {
        playButton.onClick.AddListener(playGame);
        quitButton.onClick.AddListener(OnApplicationQuit);
    }

    private void playGame()
    {
        SceneManager.LoadScene(1);
    }

    private void OnApplicationQuit()
    {
        Application.Quit();
    }
}


