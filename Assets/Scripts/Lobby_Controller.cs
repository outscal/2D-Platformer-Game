using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Lobby_Controller : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button quitButton;
    [SerializeField] GameObject Level_Selection;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
    }


    void PlayGame()
    {
        Level_Selection.SetActive(true);
    }


    void LevelMenu()
    {
        Level_Selection.SetActive(true);
    }

    void QuitGame()
    {
        //Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
