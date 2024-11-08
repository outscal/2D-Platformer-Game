using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyCOntroller : MonoBehaviour
{
    public Button buttonPlay;
    public GameObject levelSelection;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
    }

    private void PlayGame()
    {
        //SceneManager.LoadScene(1);

        SoundManager.Instance.Play(Sounds.ButtonClick); 
        levelSelection.SetActive(true); 
    }
}
