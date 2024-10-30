using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI ScoreText;

    public void Start()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        ScoreText.text = "Score: " + score.ToString();
    }
}
