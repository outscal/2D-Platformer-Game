using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button buttonStart;
    public Button quitButton;
    public GameObject LevelSelection;
    private void Awake()
    {
       buttonStart.onClick.AddListener(PlayGame);
       quitButton.onClick.AddListener(QuitGame);
    }

    private void PlayGame()
    {
        //SceneManager.LoadScene(1);
        LevelSelection.SetActive(true);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
}
