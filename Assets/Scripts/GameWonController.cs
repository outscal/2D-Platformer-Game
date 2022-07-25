using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameWonController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayNextLevel);
        quitButton.onClick.AddListener(QuitGame);

        //scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void PlayNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGameWonUI(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = "Score: " + score;
    }
}
