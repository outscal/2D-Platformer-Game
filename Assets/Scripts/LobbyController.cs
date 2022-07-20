using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    public GameObject levelSelection;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    private void PlayGame()
    {
        //SceneManager.LoadScene(1);
        levelSelection.SetActive(true);
    }
}
