using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject pauseScreen;
    public Button restartButton;
    private int count;


    private void Start()
    {
        count = 1;
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            count++;
            if(count % 2 == 0)
            {
                Time.timeScale = 0f;
                pauseScreen.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                pauseScreen.SetActive(false);
            }
        }
    }

    public void RestartLevel()
    {
        Debug.Log("restart");
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
