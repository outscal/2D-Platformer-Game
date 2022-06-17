using UnityEngine.UI;
using UnityEngine;
using System;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public GameObject levelSelectionMenu;
    // Start is called before the first frame update
    void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
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
        levelSelectionMenu.SetActive(true);
    }

}
