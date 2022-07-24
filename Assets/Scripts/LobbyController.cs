using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public Button resumeGameButton;
    public Button resetGameButton;

    public GameObject levelSelection;

    private void Awake()
    {
        resumeGameButton.onClick.AddListener(ResumeGame);
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
        resetGameButton.onClick.AddListener(ResetGame);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    private void PlayGame()
    {
        levelSelection.SetActive(true);
    }

    private void ResumeGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentLevelBeforeExiting"));
    }

    private void ResetGame()
    {
        LevelManager.Instance.ResetGameValues();
    }
}
