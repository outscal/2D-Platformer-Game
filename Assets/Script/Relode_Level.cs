using UnityEngine;
using UnityEngine.SceneManagement;

public class Relode_Level : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); 
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
