using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject healthBar;

    private int score = 0;
    private SpriteRenderer[] hearts;

    private void Start()
    {
        DisplayScore();
        hearts = healthBar.GetComponentsInChildren<SpriteRenderer>();
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

    public void UpdateHealth(int index)
    {
        if(index < 0)
        {
            return;
        }

        hearts[index].enabled = false;
    }
}
