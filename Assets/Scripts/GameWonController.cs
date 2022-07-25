using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWonController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayNextLevel);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void PlayNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGameWonUI()
    {
        gameObject.SetActive(true);
    }
}
