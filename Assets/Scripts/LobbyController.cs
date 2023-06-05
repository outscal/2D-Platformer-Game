using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button buttonLevel;
    public Button buttonPlay;
    public Button buttonSettings;
    public Button buttonResetLevels;
    public Button Backbutton;
    public GameObject LevelSelection;
    public GameObject Settingsmenu;

    void Awake()
    {
        buttonLevel.onClick.AddListener(levelSelection);
        buttonPlay.onClick.AddListener(PlayFirstLevel);
        buttonSettings.onClick.AddListener(SettingsMenu);
        buttonResetLevels.onClick.AddListener(ResetLevels);
        Backbutton.onClick.AddListener(BeckButton);
    }

    private void BeckButton()
    {
        SoundManager.Instance.Play(Sounds.ButtonClickBack);
        Settingsmenu.SetActive(false);
    }

    private void ResetLevels()
    {
        SoundManager.Instance.Play(Sounds.ButtonClickConfirm);
        LevelManager.Instance.LevelsReset();
    }

    private void SettingsMenu()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Settingsmenu.SetActive(true);
    }

    private void levelSelection()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        LevelSelection.SetActive(true);
    }

    private void PlayFirstLevel()
    {
        SoundManager.Instance.Play(Sounds.ButtonClickStart);
        SceneManager.LoadScene(1);
    }    

}
