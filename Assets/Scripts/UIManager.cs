using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Button restartButton;
    public GameObject[] lives;
    int i = 2;


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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        if(other.gameObject.GetComponent<PlayerController>() !=null)
        {
            AwakeGameOverPanel();
        }
    }

    public void DecrementLives()
    {
        lives[i].gameObject.SetActive(false);
        i--;
    }
}
