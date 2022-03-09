using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This script is used for the implementation of Game Over UI after the player health becomes 0.
/// Restart button is added to restart the level from the beginning.
/// </summary>

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;


    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
    }

    public void PlayerDead()
    {
        gameObject.SetActive(true);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
