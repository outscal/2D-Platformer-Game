using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameOverController : MonoBehaviour
{

    public Button playAgainButton;
    // prepare button to detect clicks and fire up the RestartLevel method
    private void Start()
    {
        
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
  
}
