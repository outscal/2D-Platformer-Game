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
    public Button Backbutton2;
    public Button quiteGamebutton;

    public GameObject LevelSelection;
    public GameObject Settingsmenu;
    public GameObject QuiteGame;

    void Awake()
    {
        buttonLevel.onClick.AddListener(levelSelection);
        buttonPlay.onClick.AddListener(PlayFirstLevel);
        buttonSettings.onClick.AddListener(SettingsMenu);
        buttonResetLevels.onClick.AddListener(ResetLevels);
        Backbutton.onClick.AddListener(BackButton);
        quiteGamebutton.onClick.AddListener(QuiteGamePlay);
        Backbutton2.onClick.AddListener(BackButtonPlay);

    }

    private void BackButtonPlay()
    {
        SoundManager.Instance.Play(Sounds.ButtonClickBack);
        QuiteGame.SetActive(false);
    }

    private void QuiteGamePlay()
    {
        SoundManager.Instance.Play(Sounds.ButtonClickConfirm);
        QuiteGame.SetActive(true);

    }

    private void BackButton()
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
