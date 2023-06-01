using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private GameObject levelSelection;

    private void Awake()
    {
        if(playButton != null && quitButton != null)
        {
            playButton.onClick.AddListener(StartGame);
            quitButton.onClick.AddListener(ExitGame);
        }
        else
        {
            Debug.LogError("Play/Quit button missing in the inspector");
        }
        
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        levelSelection.SetActive(true);
    }
}
