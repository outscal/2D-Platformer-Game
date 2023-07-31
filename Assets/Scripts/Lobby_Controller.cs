using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Lobby_Controller : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button levelsButton;
    [SerializeField] Button quitButton;
    [SerializeField] GameObject Level_Selection;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
        levelsButton.onClick.AddListener(LevelMenu);
        quitButton.onClick.AddListener(QuitGame);
    }


    void PlayGame()
    {
        // Get the name of the current level
        string currentLevel = PlayerPrefs.GetString("CurrentLevel", "Level_01");

        // Load the current level
        SceneManager.LoadScene(currentLevel);
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
