using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class GameOverController : MonoBehaviour
{

    public Button playAgainButton;
    public Button quitButton;
    public Button mainMenuButton;
    // prepare button to detect clicks and fire up the RestartLevel method
    private void Start()
    {
        quitButton.onClick.AddListener(QuitGame);
        playAgainButton.onClick.AddListener(RestartLevel);
        mainMenuButton.onClick.AddListener(GoToLobby);
        Debug.Log("Awoke");
        
    }

    private void GoToLobby()
    {
        SceneManager.LoadScene(0);
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
