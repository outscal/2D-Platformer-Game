using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour {

    private int score = 0;

    public void AddScore(int s) {
        score += s;
        UpdateScoreText();
    }

    private void UpdateScoreText() {
        GetComponent<Text>().text = "Score: " + score;
    }
}
