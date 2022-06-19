using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class GameOverController : MonoBehaviour
{

    public Button playAgainButton;
    public Button quitButton;
    public Button mainMenuButton;
    public Button nextLevelButton;
    // prepare button to detect clicks and fire up the RestartLevel method
    private void Start()
    {
        quitButton.onClick.AddListener(QuitGame);
        playAgainButton.onClick.AddListener(RestartLevel);
        mainMenuButton.onClick.AddListener(GoToLobby);
        nextLevelButton.onClick.AddListener(NextLevel);
        
        
    }

    private void GoToLobby()
    {
        SoundManager.Instance.Play(Sounds.ButtonClickUnlocked);
        SceneManager.LoadScene(0);
    }

    // Show the GameOver Image & Button
    public void PlayerDied()
    {
        gameObject.SetActive(true);
        
        GameManager.Instance.resetPlayerScore();
    }
    public void LevelCompleted()
    {
        gameObject.SetActive(true);
        GameManager.Instance.isGamePaused = true;
    }

    // Reload the current active level/scene
    public void RestartLevel()
    {
        SoundManager.Instance.Play(Sounds.ButtonClickUnlocked);
        GameManager.Instance.resetPlayerScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Application.Quit();
    }
    public void NextLevel()
    {
       
        SoundManager.Instance.Play(Sounds.ButtonClickUnlocked);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
