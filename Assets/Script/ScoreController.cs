using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score;
    
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        RefreshUI();
    }


    public void increaseScore(int increament)
    {
        score += increament;
        RefreshUI();
    }

    private void RefreshUI()
    {
        scoreText.text = "Score :" + score.ToString();
    }


}
