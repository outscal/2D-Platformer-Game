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
        buttonPlay.onClick.AddListener(PlayLastLevel);
        buttonSettings.onClick.AddListener(SettingsMenu);
        buttonResetLevels.onClick.AddListener(ResetLevels);
        Backbutton.onClick.AddListener(BeckButton);
    }

    private void BeckButton()
    {
        Settingsmenu.SetActive(false);
    }

    private void ResetLevels()
    {
        LevelManager.Instance.LevelsReset();
    }

    private void SettingsMenu()
    {
        Settingsmenu.SetActive(true);
    }

    private void levelSelection()
    {
        LevelSelection.SetActive(true);
    }

    private void PlayLastLevel()
    {
        SceneManager.LoadScene(1);

    }
   
    

    
    

}
