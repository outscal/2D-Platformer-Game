using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static SoundManager;

public class PlayButton: MonoBehaviour
{
    public Button playButton;
    private void Awake()
    {
        playButton.onClick.AddListener(PlayGame);         

    }
    private void PlayGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(1);

    }


}
