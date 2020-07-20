using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Button restartButton;
    


    public void RestartLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    public void Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void AwakeGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

   
    
}
