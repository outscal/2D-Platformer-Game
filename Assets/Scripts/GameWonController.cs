using UnityEngine;
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

    // running CloneTotalScoretextUI function in start gives null reference exception

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
        LevelManager.Instance.PlayNextLevel();
    }

    public void LoadGameWonUI(int levelScore)
    {
        gameObject.SetActive(true);
        scoreText.text = "Level Score: " + levelScore;
        ModifyTotalScore(levelScore);
    }

    //Reset total score in LobbyController: line 32 
    private void ModifyTotalScore(int levelScore)
    {
        totalScore = PlayerPrefs.GetInt("totalScore", 0);
        totalScore += levelScore;
        PlayerPrefs.SetInt("totalScore", totalScore);
        totalScoreText.text = "Total Score: " + totalScore;
    }
}
