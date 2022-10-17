using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    int score;

    
  private void Awake()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        
    }
    private void Start()
    {
        RefreshUI();
    }
public void IncreaseScore(int scoreIncrement)
{
    score = score + scoreIncrement;
    RefreshUI();
}
private void RefreshUI()
{
    scoreText.text = "Score: " + score;
}
   
}
