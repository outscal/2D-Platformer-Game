using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;
    void Start()
    {
        score = 0;
        refreshOnScreen();
    }

    public void setScore(int score)
    {
        this.score += score;
        refreshOnScreen();
    }

    private void refreshOnScreen()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Score : " + score;

    }
}
