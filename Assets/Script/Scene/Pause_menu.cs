
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause_menu : MonoBehaviour
{

    [SerializeField] GameObject Pause_panel;
    // Start is called before the first frame update
    void Start()
    {
        Pause_panel.SetActive(false);
    }

    public void Pause()
    {
        Pause_panel.SetActive(true);
        Time.timeScale = 0f;
        
    }

    private int CurrentBuildIndex;
    public void menu()
    {
        CurrentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", CurrentBuildIndex);
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        Pause_panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

}
