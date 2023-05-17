using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Increase_score : MonoBehaviour
{
    private TextMeshProUGUI score_text;
    private int score = 0;

    private void Awake()
    {
        score_text = GetComponent<TextMeshProUGUI>();
    }

    public void update_score()
    {
        score += 1;
        score_refresh();
    }

    private void score_refresh()
    {
        score_text.text = "Score : " + score;
    }
}
