using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public Button buttonPlay;
    public Button quit;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
        quit.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application Quit");
        //throw new NotImplementedException();
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("S2");
        //throw new NotImplementedException();
    }
}
