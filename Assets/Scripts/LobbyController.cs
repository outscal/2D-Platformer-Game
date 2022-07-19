using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
       // Application.Quit will not work inside unity editor
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    private void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
