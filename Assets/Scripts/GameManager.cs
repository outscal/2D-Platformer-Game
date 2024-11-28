using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public string sceneName;
    public Animator animator;

    // Function to handle game over state
    public void Die()
    {
        // Set the animation for death if needed and activate the game over panel
       animator.SetBool("isDead", true);
        GameOverPanel.SetActive(true);
        //StartCoroutine(ReloadSceneAfterDelay(1f));
    }

    // Function to restart the game
    public void RestartGame()
    {
        ReloadCurrentScene();
        Time.timeScale = 1;
    }

    // Function to quit the game
    public void QuitGame()
    {
        Application.Quit();
        Time.timeScale = 1;
    }

    // Coroutine to reload the scene after a specified delay
    private IEnumerator ReloadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ReloadCurrentScene();
    }

    // Function to reload the current scene
    private void ReloadCurrentScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    // Function to load a specific scene
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
