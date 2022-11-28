using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField] Button buttonStart;
    [SerializeField] Button quitButton;
    [SerializeField] GameObject LevelSelection;
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
