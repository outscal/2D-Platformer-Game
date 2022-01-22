﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button buttonPlay;
    public GameObject LevelSelection;
    public AudioSource click;
    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
    }

    private void PlayGame()
    { 
        SoundManager.Instance.Play(Sounds.ButtonClick);
       // SceneManager.LoadScene(1);
       LevelSelection.SetActive(true);
        click.Play();
    }
}
