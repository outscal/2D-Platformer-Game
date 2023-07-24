using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayButton: MonoBehaviour
{
    public Button playButton;
    private void Awake()
    {
        playButton.onClick.AddListener(PlayGame);         

    }
    private void PlayGame()
    {
        SceneManager.LoadScene(1);

    }


}
