using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private int score = 0;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        RefreshUI();
    }

    public void IncrementScore(int increment)
    {
        score += increment;
        PlayerPrefs.SetInt("score", score);
        RefreshUI();
    }

    private void RefreshUI()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("score");
    }
}
