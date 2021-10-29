
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
   
    public GameObject pausePanel;
    public GameObject player;
    public bool isPaused;
   
    private void Start()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        

    }
    private void Update()
    {
        PauseAndResume();
    }

    private void PauseAndResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused) pauseGame();
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused) resume();
    }

    public void play()
    {
        PlayerPrefs.SetInt("levelsCleared",0);
        SceneManager.LoadScene(1);
    }
    
    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(0);   
    }
    public void Quit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
    public void pauseGame()
    {
        print("Paused");
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        isPaused = true;
    }
    public void resume()
    {
        print("Resumed");
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        isPaused = false;
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("sceneNoo"))
            SceneManager.LoadScene(PlayerPrefs.GetInt("sceneNoo"));
        else
            SceneManager.LoadScene(1);
    }

    public void LoadLevel1 ()
    {
        SceneManager.LoadScene(1);
       
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(2);
        
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(3);

    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(4);

    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene(5);

    }


}
