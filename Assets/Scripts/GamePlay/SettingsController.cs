using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Button LobbyBtn;
    public Button QuitBtn; 

    private void Awake()
    {
        LobbyBtn.onClick.AddListener(onLobbyBtnClick);
        QuitBtn.onClick.AddListener(onQuitBtnClick); 
    }

    private void onLobbyBtnClick()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
        SceneManager.LoadScene("Lobby");
    }

    public void onQuitBtnClick()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
        Application.Quit();
    }
}
