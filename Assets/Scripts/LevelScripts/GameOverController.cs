using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameOverController : MonoBehaviour
{

    public Button playAgainButton;
    public Button quitButton;
    // prepare button to detect clicks and fire up the RestartLevel method
    private void Start()
    {
        quitButton.onClick.AddListener(QuitGame);
        playAgainButton.onClick.AddListener(RestartLevel);
        Debug.Log("Awoke");
    }
    // Show the GameOver Image & Button
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    // Reload the current active level/scene
    public void RestartLevel()
    {
        Debug.Log("Trying to laod");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Application.Quit();
    }

}
