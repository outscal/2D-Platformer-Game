using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        DisplayScore();
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.text = "Score : " + score;
    }
}
