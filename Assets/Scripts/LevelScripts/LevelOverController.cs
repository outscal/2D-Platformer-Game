using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    public int totalLevels = 3;
    public Transform levelBegin;
    public GameOverController levelCompleteController;
    void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Scene _currentLevel = SceneManager.GetActiveScene();
            LevelManager.Instance.setLevelStatus(_currentLevel.name, LevelStatus.Completed);
            LevelManager.Instance.setLevelStatus("Level" + (_currentLevel.buildIndex+1).ToString(), LevelStatus.Unlocked);
            // Load the next level, however loop back from last level to level 1.
            levelCompleteController.LevelCompleted();
            //SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
        }
        
    }
}
