using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    public string levelName;
    public GameObject gameOverPanel;
    public Button restartButton;
    private void Awake()
    {
        restartButton.onClick.AddListener(RestartLevel);
    }


    private void RestartLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
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
}
