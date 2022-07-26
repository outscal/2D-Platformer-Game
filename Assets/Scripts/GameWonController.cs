using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameWonController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    public TextMeshProUGUI scoreText;

    private TextMeshProUGUI totalScoreText;
    private int totalScore;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayNextLevel);
        quitButton.onClick.AddListener(QuitGame);
        CloneTotalScoreTextUI();

    }

    private void Start()
    {
    }

    private void CloneTotalScoreTextUI()
    {
        Vector3 scoreTextPosition = scoreText.rectTransform.position;
        scoreTextPosition.y -= 60;
        totalScoreText = Instantiate(scoreText, scoreTextPosition, Quaternion.identity, gameObject.transform);
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
        scoreText.text = "Level Score: " + score;
        ModifyTotalScore(score);
    }

    //Reset total score in LobbyController: line 32 
    private void ModifyTotalScore(int score)
    {
        totalScore = PlayerPrefs.GetInt("totalScore", 0);
        totalScore += score;
        PlayerPrefs.SetInt("totalScore", totalScore);
        totalScoreText.text = "Total Score: " + totalScore;
    }
}
