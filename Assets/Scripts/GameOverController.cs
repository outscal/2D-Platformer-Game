using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Button restartButton;
    public Button quitButton;
    private int levelPlayerDiedOn;

    public void Awake()
    {
        restartButton.onClick.AddListener(ReloadLevel);
        quitButton.onClick.AddListener(QuitGame);
    }
    public void QuitGame()
    {

        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public int GetIntLevel(string keyName)
    {
        return PlayerPrefs.GetInt(keyName);
    }

    public void SetIntLevel(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public void LoadGameOverUI()
    {
        gameObject.SetActive(true);
        //can allow to resume on the level after player dies and quits.
        levelPlayerDiedOn = SceneManager.GetActiveScene().buildIndex;
        SetIntLevel("currentLevel", levelPlayerDiedOn);
    }

    // load level won UI panel

    //reloadlevel should also be ui function
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
