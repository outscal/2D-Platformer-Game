//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    int score = 0;
    int heartCount = 3;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }

    public void IncreaseScore(int increment)
    {
        score += increment;
        RefreshUI();
    }

    public void DecreaseHeartCount()
    {
        heartCount -= 1;
    }
    private void RefreshUI()
    {
        scoreText.text = "Score: " + score;
    }
        
}
