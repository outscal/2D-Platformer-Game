using UnityEngine.UI;
using UnityEngine;
using System;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public Button optionsButton;
    public Button quitButton;
    public GameObject levelSelectionMenu;
    public GameObject optionsMenu;
    public Slider volumeSlider;
    // Start is called before the first frame update
    void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
        optionsButton.onClick.AddListener(ShowOptionsMenu);
}

    private void ShowOptionsMenu()
    {
        SoundManager.Instance.Play(Sounds.ButtonClickUnlocked);
        optionsMenu.SetActive(true);
    }

    private void QuitGame()
    {
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Application.Quit();
    }

    private void PlayGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClickUnlocked);
        levelSelectionMenu.SetActive(true);
    }
    public void Start()
    {
        volumeSlider.onValueChanged.AddListener((v) =>
        {
            SoundManager.Instance.setVolume(v);
        });
     }

}
