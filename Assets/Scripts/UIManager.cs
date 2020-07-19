using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Button restartButton;
    


    public void RestartLevel()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    public void Lobby()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene("Lobby");
    }

    public void AwakeGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

   
    
}
