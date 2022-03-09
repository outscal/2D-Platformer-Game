using UnityEngine;
using TMPro;

/// <summary>
/// This script is used for the implementation of the score increment after picking up the Collectible Key by the player
/// Shows the ScoreUI
/// </summary>

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score = 0;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();    
    }

    void Start()
    {
        RefreshUI();
    }

    public void IncrementScore(int increment)
    {
        score += increment;
        RefreshUI();
    }

    private void RefreshUI()
    {
        scoreText.text = "SCORE: " + score;
    }


}
