using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour
{
    private TMP_Text text_score;
    private int score;

    private void Awake()
    {
        text_score = GetComponent<TMP_Text>();
    }

    public void UpdateScore(int value)
    {
        score += value;
        RefreshUI();
    }

    private void RefreshUI()
    {
        text_score.text = "score : "+score.ToString();
    }

}
