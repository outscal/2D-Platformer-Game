using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuConroller : MonoBehaviour
{
    public Button playButton;
    public Button backButton;
    public GameObject selectLevels;
    private void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
        backButton.onClick.AddListener(closePopUp);
        soundManager.Instance.PlayBGMusic(Music.lobbyBgMusic);
    }

    private void closePopUp()
    {
        selectLevels.SetActive(false);
    }

    private void PlayGame()
    {
        selectLevels.SetActive(true);
    }
}
