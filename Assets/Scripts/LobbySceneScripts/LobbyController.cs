using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public string levelName;
    private void Awake()
    {
        playButton.onClick.AddListener(StartGame);
    }

    
    private void StartGame()
    {
        SceneManager.LoadScene(levelName);
    }
}
