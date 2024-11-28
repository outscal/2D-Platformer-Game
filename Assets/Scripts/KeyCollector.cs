using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyCollector : MonoBehaviour
{
    private bool hasKey = false;
    public GameObject keyUI; // UI element to show when key is collected
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("key"))
        {
            // Collect the key
            hasKey = true;
            keyUI.SetActive(true); // Display key in the UI (optional)
            Destroy(collision.gameObject); // Remove the key from the scene
        }
        else if (collision.CompareTag("Win"))
        {
            // Check if player has the key when reaching the win area
            if (hasKey)
            {
                WinGame();
            }
            else
            {
                Debug.Log("You need the key to proceed!");
            }
        }
    }

    private void WinGame()
    {
        Debug.Log("Congratulations! You won the level.");
        // Get the current level index
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int lastLevelIndex = SceneManager.sceneCountInBuildSettings - 1;

        // Unlock the next level only if the current level index is less than the last index
        if (currentLevelIndex < lastLevelIndex)
        {
            LevelLockManager.Instance.UnlockNextLevel(currentLevelIndex);
        }
        gameManager.LoadScene();

        // Add code here to load the next level or trigger the win screen
        // For example, using SceneManager to load the next level:
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
