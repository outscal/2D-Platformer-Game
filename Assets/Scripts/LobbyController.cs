using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public GameObject LevelSelectionParent; 
    private void Start()
    {
        playButton.onClick.AddListener(LevelSelection);
    }

    private void LevelSelection()
    {
        SoundManager.Instance.Play(SoundList.ButtonClickPlay); 
        playButton.gameObject.SetActive(false);
        LevelSelectionParent.SetActive(true);


    }






}
