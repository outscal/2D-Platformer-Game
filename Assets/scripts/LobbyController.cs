using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LobbyController : MonoBehaviour
{
    public Button buttonPlay;
    public GameObject LevelSelection;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
    }
    private void PlayGame()
    {
        //SceneManager.LoadScene(1);
        LevelSelection.SetActive(true);
    }
}
