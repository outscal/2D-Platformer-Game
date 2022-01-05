using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class LobbyController : MonoBehaviour
{
    public Button playButton;
    
    public GameObject LevelSelection;

    private void Awake()
    {
        playButton.onClick.AddListener(Playgame);
       
    }

    

    private void Playgame()
    {
        LevelSelection.SetActive(true);
    }
}
