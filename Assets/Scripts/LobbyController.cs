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
    public GameObject LevelSelection;

    void Awake()
    {
        buttonLevel.onClick.AddListener(levelSelection);
        buttonPlay.onClick.AddListener(PlayLastLevel);

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
