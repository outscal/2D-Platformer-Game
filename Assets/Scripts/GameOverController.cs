using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Button restartButton;
    public Button quitButton;

    public void Awake()
    {
        restartButton.onClick.AddListener(ReloadLevel);
        quitButton.onClick.AddListener(QuitGame);
    }
    public void QuitGame()
    {
        // Application.Quit will not work inside unity editor
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void LoadGameOverUI()
    {
        gameObject.SetActive(true);
    }

    // load level won UI panel

    //reloadlevel should also be ui function
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
