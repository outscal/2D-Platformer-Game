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
        
      
    }
    private void Start()
    {
        soundManager.Instance.PlayBGMusic(Music.lobbyBgMusic);
    }


    private void closePopUp()
    {
        soundManager.Instance.Play(Sounds.ButtonClickLocked);
        selectLevels.SetActive(false);
    }

    private void PlayGame()
    {
        soundManager.Instance.Play(Sounds.ButtonClickNormal);

        selectLevels.SetActive(true);
    }
}
