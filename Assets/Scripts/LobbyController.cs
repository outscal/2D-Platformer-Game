using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button btnPlay;
    public Button btnQuit;
    //public string sceneName;

    private void Awake()
    {
        btnPlay.onClick.AddListener(StartPlay);
        btnQuit.onClick.AddListener(QuitGame);
    }

    public void StartPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
