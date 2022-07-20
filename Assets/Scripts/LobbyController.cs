using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public Button resumeGameButton;

    public GameObject levelSelection;

    private void Awake()
    {
        resumeGameButton.onClick.AddListener(ResumeGame);
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
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
        //lazy implementation. Load gameOverController script and then use Getter method from gameOverController instance.
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentLevel"));
    }
}
